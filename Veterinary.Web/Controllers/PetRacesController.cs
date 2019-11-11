using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Web.Data.Entities;
using Veterinary.Web.Models.Data;

namespace Veterinary.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PetRacesController : Controller
    {
        private readonly DataContext _context;

        public PetRacesController(DataContext context)
        {
           _context = context;
        }

        public async Task<ActionResult> Index()
        {
           return View(await _context.PetRaces.ToListAsync());
        }


        public ActionResult Create()
        {
            return View();        
        }

        [HttpPost]
        public async Task<JsonResult> Create(PetRace model)
        {
            var result = "Fail";

            if (ModelState.IsValid)
            {
                _context.Add(model); 

                try
                {
                    await _context.SaveChangesAsync();
                    result = "Success";
                    //Todo: Refactor retur hredirect
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());                   
                }
            }

            return Json(result);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petRace = await _context.PetRaces.FindAsync(id);
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
                    _context.Update(petRace);
                    await _context.SaveChangesAsync();
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
            return _context.PetRaces.Any(e => e.Id == id);
        }
    }
}
