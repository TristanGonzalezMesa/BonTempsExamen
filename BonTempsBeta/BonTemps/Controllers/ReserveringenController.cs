using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Data;
using BonTemps.Models;

namespace BonTemps.Controllers
{
    public class ReserveringenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReserveringenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reserveringen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reserveringen.Include(r => r.Klant).ToListAsync());
        }

        // GET: Reserveringen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Naam");

            if (id == null)
            {
                return NotFound();
            }

            var reserveringen = await _context.Reserveringen.Include(r=>r.Klant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserveringen == null)
            {
                return NotFound();
            }

            return View(reserveringen);
        }

        // GET: Reserveringen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reserveringen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,Tijd,KlantId")] Reservering reserveringen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserveringen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserveringen);
        }

        // GET: Reserveringen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveringen = _context.Reserveringen.Include(r => r.Klant).Where(r => r.Id == id).FirstOrDefault();
            if (reserveringen == null)
            {
                return NotFound();
            }
            return View(reserveringen);
        }

        // POST: Reserveringen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,Tijd,KlantId")] Reservering reserveringen)
        {
            if (id != reserveringen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserveringen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveringenExists(reserveringen.Id))
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
            return View(reserveringen);
        }

        // GET: Reserveringen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveringen = await _context.Reserveringen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserveringen == null)
            {
                return NotFound();
            }

            return View(reserveringen);
        }

        // POST: Reserveringen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserveringen = await _context.Reserveringen.FindAsync(id);
            _context.Reserveringen.Remove(reserveringen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveringenExists(int id)
        {
            return _context.Reserveringen.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> Factuur(int id)
        {

            //var test = await _context.Reserveringen.Include(r => r.Klant)
            //  .FirstOrDefaultAsync(m => m.Id == id);
            //{
            //    return NotFound();

            //}

            var reserveringen = await _context.ReserveringMenus
                .Include(rm => rm.Reservering)
                .ThenInclude(rm => rm.Klant)
                .Include(rm => rm.Menu)
                .Where(f => f.ReserveringId == id)
                .ToListAsync();

            var reserveringensum = reserveringen.Sum(r => r.Aantal);
            var totaalexbtw = reserveringen.Sum(r => r.Menu.Prijs);
            var btw = totaalexbtw * 0.21m;
            var totaal = btw + totaalexbtw;

            FactuurViewModel factuur = new FactuurViewModel();
            factuur.BTW = btw;
            factuur.TotaalAantal = reserveringensum;
            factuur.TotaalPrijs = totaal;
            factuur.TotaalPrijsExBTW = totaalexbtw;
            factuur.Reserveringen = reserveringen;

            return View(factuur);
        }
        //POST Reserveringen.AddMenu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMenu(ReserveringMenu ReserveringMenu)
        {
            var existingReserveringMenu = await _context.ReserveringMenus
                .FindAsync(ReserveringMenu.ReserveringId, ReserveringMenu.MenuId);

            if (existingReserveringMenu == null)
            {
                _context.Add(ReserveringMenu);
            }
            else
            {
                existingReserveringMenu.Aantal = ReserveringMenu.Aantal;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = ReserveringMenu.ReserveringId });
        }

    }
}
