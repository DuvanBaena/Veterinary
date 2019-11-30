using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Veterinary.Web.Data.Entities;
using Veterinary.Web.Models.Data;

namespace Veterinary.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PetRacesController : Controller
    {
        private readonly DataContext _dataContext;

        public PetRacesController(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<ActionResult> Index()
        {
           return View(await _dataContext.PetRaces.ToListAsync());
        }


        public ActionResult Create()
        {
            return View();        
        }

        [HttpPost]
        public async Task<JsonResult> Create(PetRace model)
        {
            var message = string.Empty;

            var race = await _dataContext.PetRaces
                .FirstOrDefaultAsync(o => o.Name == model.Name);

            if (ModelState.IsValid)
            {
                _dataContext.Add(model);
                try
                { 
                    if (race != null)
                    {
                        message = "Exist";

                    }
                    else
                    {
                        message = "Success";
                        await _dataContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                }
            }
            return Json(message);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petRace = await _dataContext.PetRaces.FindAsync(id);
            if (petRace == null)
            {
                return NotFound();
            }
            return View(petRace);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PetRace petRace)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(petRace);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetRaceExists(petRace.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(petRace);
        }

        private bool PetRaceExists(int id)
        {
            return _dataContext.PetRaces.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petRace = await _dataContext.PetRaces.FirstOrDefaultAsync(m => m.Id == id);

            if (petRace == null)
            {
                return NotFound();
            }

            return View(petRace);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petRace = await _dataContext.PetRaces
                .Include(pr => pr.Pets)
                .FirstOrDefaultAsync(pr => pr.Id == id);

            if (petRace == null)
            {
                return NotFound();
            }

            if (petRace.Pets.Count > 0)
            {

                ModelState.AddModelError(string.Empty, "The pet type can´t be removed ");
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _dataContext.PetRaces.Remove(petRace);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.ToString());
                return RedirectToAction(nameof(Index));
            }
        }


    }
}
