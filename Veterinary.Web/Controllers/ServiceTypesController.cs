using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Web.Data.Entities;
using Veterinary.Web.Models.Data;

namespace Veterinary.Web.Controllers
{
    public class ServiceTypesController : Controller
    {
        private readonly DataContext _context;

        public ServiceTypesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceTypes.ToListAsync());
        }
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _context.ServiceTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {

            if (ModelState.IsValid)
            {
                _context.Add(serviceType);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View();
                }
            }
            return View(serviceType);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _context.ServiceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceTypeExists(serviceType.Id))
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
            return View(serviceType);
        }
    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _context.ServiceTypes
            .Include(h => h.Histories)
            .FirstOrDefaultAsync(h => h.Id == id);

            if (serviceType == null)
            {
                return NotFound();
            }

            if (serviceType.Histories.Count > 0)
            {

                ModelState.AddModelError(string.Empty, "The pet Servicetype can´t be removed ");
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.ServiceTypes.Remove(serviceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.ToString());
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ServiceTypeExists(int id)
        {
            return _context.ServiceTypes.Any(e => e.Id == id);
        }
    }
}
