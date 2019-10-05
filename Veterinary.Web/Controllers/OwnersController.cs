﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Veterinary.Web.Data.Entities;
using Veterinary.Web.Helpers;
using Veterinary.Web.Models;
using Veterinary.Web.Models.Data;

namespace Veterinary.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OwnersController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IMailHelper _mailHelper;

        public OwnersController(
            DataContext context, 
            IUserHelper userHelper,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper,
            IImageHelper imageHelper,
            IMailHelper mailHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
            _mailHelper = mailHelper;
        }

        // GET: Owners
        public IActionResult Index()
        {
            return View( _dataContext.Owners
                .Include(o => o.User)
                .Include(o=> o.Pets));
        }
   
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _dataContext.Owners
                .Include(o => o.User)
                .Include(o => o.Pets)
                .ThenInclude(p => p.PetType)
                .Include(o => o.Pets)
                .ThenInclude(p => p.Histories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }
        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            Thread.Sleep(4000);

            if (ModelState.IsValid)
            {
                //var result = "Fail";
                var user = new User
                {

                    Address = model.Address,
                    Document = model.Document,
                    Email = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Username,
                    BusinessName = model.BusinessName,
                    LandlinePhone = model.LandlinePhone,

                };

                var response = await _userHelper.AddUserAsync(user, model.Password);

                if (response.Succeeded)
                {
                    var userInDb = await _userHelper.GetUserByEmailAsync(model.Username);
                    await _userHelper.AddUserToRoleAsync(userInDb, "Customer");

                    var owner = new Owner
                    {
                        Agendas = new List<Agenda>(),
                        Pets = new List<Pet>(),
                        User = userInDb,
                    };

                    _dataContext.Owners.Add(owner);

                    try
                    {
                        await _dataContext.SaveChangesAsync();
                        //result = "Success";

                        var myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                        var tokenLink = Url.Action("ConfirmEmail", "Account", new
                        {
                            userid = user.Id,
                            token = myToken
                        }, protocol: HttpContext.Request.Scheme);

                        _mailHelper.SendMail(model.Username, "Email confirmation", $"<h1>Email Confirmation</h1>" +
                            $"To allow the user, " +
                            $"plase click in this link:</br></br><a href = \"{tokenLink}\">Confirm Email</a>");

                        return RedirectToAction(nameof(Index));

                    }
                    catch (Exception ex)
                    {

                        ModelState.AddModelError(string.Empty, ex.ToString());
                        return View(model);
                       
                    }

                   // return Json(result);
                }

                ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
            }

            return View(model);
           
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _dataContext.Owners
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (owner == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                Address = owner.User.Address,
                Document = owner.User.Document,
                FirstName = owner.User.FirstName,
                Id = owner.Id,
                LastName = owner.User.LastName,
                PhoneNumber = owner.User.PhoneNumber,
                BusinessName = owner.User.BusinessName,
                LandlinePhone = owner.User.LandlinePhone,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var owner = await _dataContext.Owners
                    .Include(o => o.User)
                    .FirstOrDefaultAsync(o => o.Id == model.Id);

                owner.User.Document = model.Document;
                owner.User.FirstName = model.FirstName;
                owner.User.LastName = model.LastName;
                owner.User.Address = model.Address;
                owner.User.PhoneNumber = model.PhoneNumber;
                owner.User.BusinessName = model.BusinessName;
                owner.User.LandlinePhone = model.LandlinePhone;

                try
                {
                    await _userHelper.UpdateUserAsync(owner.User);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _dataContext.Owners
                .Include(o => o.User)
                .Include(o => o.Pets)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            if (owner.Pets.Count > 0)
            {
                //TODO: Menssage
                return RedirectToAction(nameof(Index));
            }

            await _userHelper.DeleteUserAsync(owner.User.Email);

            try
            {
                _dataContext.Owners.Remove(owner);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.ToString());
                return RedirectToAction(nameof(Index));
            }
        }

        private bool OwnerExists(int id)
        {
            return _dataContext.Owners.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> AddPet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _dataContext.Owners.FindAsync(id.Value);

            if (owner == null)
            {
                return NotFound();
            }

            var model = new PetViewModel
            {
                Born = DateTime.Today,
                OwnerId = owner.Id,
                PetTypes = _combosHelper.GetComboPetTypes()

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPet(PetViewModel model)
        {
            Thread.Sleep(4000);

            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);
                }

                var pet = await _converterHelper.ToPetAsync(model, path, true);

                _dataContext.Pets.Add(pet);

                try
                {                   
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction($"Details/{model.OwnerId}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }

            model.PetTypes = _combosHelper.GetComboPetTypes();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditPet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _dataContext.Pets
                .Include(p => p.Owner)
                .Include(p => p.PetType)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pet == null)
            {
                return NotFound();
            }


            return View(_converterHelper.ToPetViewModel(pet));
        }

        [HttpPost]
        public async Task<IActionResult> EditPet(PetViewModel model)
        {
            Thread.Sleep(4000);

            if (ModelState.IsValid)
            {
                var path = model.ImageUrl;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);
                }

                var pet = await _converterHelper.ToPetAsync(model, path, false);               

                try
                {
                    _dataContext.Pets.Update(pet);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction($"Details/{model.OwnerId}");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }
            model.PetTypes = _combosHelper.GetComboPetTypes();
            return View(model);
        }

        public async Task<IActionResult> DetailsPet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _dataContext.Pets
                .Include(p => p.Owner)
                .ThenInclude(o => o.User)
                .Include(p => p.Histories)
                .ThenInclude(h => h.ServiceType)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        public async Task<IActionResult> AddHistory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _dataContext.Pets.FindAsync(id.Value);
            if (pet == null)
            {
                return NotFound();
            }

            var model = new HistoryViewModel
            {
                Date = DateTime.Now,
                PetId = pet.Id,
                ServiceTypes = _combosHelper.GetComboServiceTypes(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddHistory(HistoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var history = await _converterHelper.ToHistoryAsync(model, true);

                try
                {
                    _dataContext.Histories.Add(history);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsPet)}/{model.PetId}");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }

            model.ServiceTypes = _combosHelper.GetComboPetTypes();
            return View(model);
        }

        public async Task<IActionResult> EditHistory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _dataContext.Histories
                .Include(h => h.Pet)
                .Include(h => h.ServiceType)
                .FirstOrDefaultAsync(p => p.Id == id.Value);
            if (history == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToHistoryViewModel(history));
        }

        [HttpPost]
        public async Task<IActionResult> EditHistory(HistoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var history = await _converterHelper.ToHistoryAsync(model, false);

                try
                {
                    _dataContext.Histories.Update(history);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsPet)}/{model.PetId}");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }

            model.ServiceTypes = _combosHelper.GetComboPetTypes();
            return View(model);
        }

        public async Task<IActionResult> DeleteHistory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _dataContext.Histories
                .Include(h => h.Pet)
                .FirstOrDefaultAsync(h => h.Id == id.Value);
            if (history == null)
            {
                return NotFound();
            }

            try
            {
                _dataContext.Histories.Remove(history);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(DetailsPet)}/{history.Pet.Id}");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.ToString());
                return RedirectToAction($"{nameof(DetailsPet)}/{history.Pet.Id}");
            }
        }

        public async Task<IActionResult> DeletePet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _dataContext.Pets
                .Include(p => p.Owner)
                .Include(p => p.Histories)
                .FirstOrDefaultAsync(p => p.Id == id.Value);
            if (pet == null)
            {
                return NotFound();
            }

            if (pet.Histories.Count > 0)
            {

                ModelState.AddModelError(string.Empty, "The pet can´t be deleted because it has related records");
                return RedirectToAction($"{nameof(Details)}/{pet.Owner.Id}");
            }

            try
            {
                _dataContext.Pets.Remove(pet);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{pet.Owner.Id}");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.ToString());
                return RedirectToAction($"{nameof(Details)}/{pet.Owner.Id}");
            }
        }
    }
}
