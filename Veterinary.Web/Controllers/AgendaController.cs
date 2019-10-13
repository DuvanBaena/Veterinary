using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Web.Helpers;
using Veterinary.Web.Models;
using Veterinary.Web.Models.Data;

namespace Veterinary.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AgendaController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IAgendaHelper _agendaHelper;
        private readonly ICombosHelper _combosHelper;

        public AgendaController(
            DataContext context,
            IAgendaHelper agendaHelper,
            ICombosHelper combosHelper)
        {
            _dataContext = context;
            _agendaHelper = agendaHelper;
            _combosHelper = combosHelper;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Agendas
                .Include(a => a.Owner)
                .ThenInclude(o => o.User)
                .Include(a => a.Pet)
                .Where(a => a.Date >= DateTime.Today.ToLocalTime()));
        }

        public async Task<IActionResult> AddDays()
        {
            await _agendaHelper.AddDaysAsync(7);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Assing(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _dataContext.Agendas
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (agenda == null)
            {
                return NotFound();
            }

            var modal = new AgendaViewModel
            {
                Id = agenda.Id,
                Owners = _combosHelper.GetComboOwners(),
                Pets = _combosHelper.GetComboPets(0)
            };

            return View(modal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assing(AgendaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var agenda = await _dataContext.Agendas.FindAsync(model.Id);
                if (agenda != null)
                {
                    agenda.IsAvailable = false;
                    agenda.Owner = await _dataContext.Owners.FindAsync(model.OwnerId);
                    agenda.Pet = await _dataContext.Pets.FindAsync(model.PetId);
                    agenda.Remarks = model.Remarks;
                    _dataContext.Agendas.Update(agenda);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            model.Owners = _combosHelper.GetComboOwners();
            model.Pets = _combosHelper.GetComboPets(model.OwnerId);

            return View(model);
        }

        public async Task<JsonResult> GetPetsAsync(int ownerId)
        {
            var pets = await _dataContext.Pets
                .Where(p => p.Owner.Id == ownerId)
                .OrderBy(p => p.Name)
                .ToListAsync();
            return Json(pets);
        }

        public async Task<IActionResult> Unassign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _dataContext.Agendas
                .Include(a => a.Owner)
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (agenda == null)
            {
                return NotFound();
            }

            agenda.IsAvailable = true;
            agenda.Pet = null;
            agenda.Owner = null;
            agenda.Remarks = null;

            _dataContext.Agendas.Update(agenda);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}

