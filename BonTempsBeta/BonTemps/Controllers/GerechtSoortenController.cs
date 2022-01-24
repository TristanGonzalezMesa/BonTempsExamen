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
    public class GerechtSoortenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerechtSoortenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GerechtSoorten
        public async Task<IActionResult> Index()
        {
            return View(await _context.GerechtSoorten.ToListAsync());
        }

        // GET: GerechtSoorten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtSoorten = await _context.GerechtSoorten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerechtSoorten == null)
            {
                return NotFound();
            }

            return View(gerechtSoorten);
        }

        // GET: GerechtSoorten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GerechtSoorten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Soort")] GerechtSoort gerechtSoorten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerechtSoorten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gerechtSoorten);
        }

        // GET: GerechtSoorten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtSoorten = await _context.GerechtSoorten.FindAsync(id);
            if (gerechtSoorten == null)
            {
                return NotFound();
            }
            return View(gerechtSoorten);
        }

        // POST: GerechtSoorten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Soort")] GerechtSoort gerechtSoorten)
        {
            if (id != gerechtSoorten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerechtSoorten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerechtSoortenExists(gerechtSoorten.Id))
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
            return View(gerechtSoorten);
        }

        // GET: GerechtSoorten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtSoorten = await _context.GerechtSoorten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerechtSoorten == null)
            {
                return NotFound();
            }

            return View(gerechtSoorten);
        }

        // POST: GerechtSoorten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerechtSoorten = await _context.GerechtSoorten.FindAsync(id);
            _context.GerechtSoorten.Remove(gerechtSoorten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerechtSoortenExists(int id)
        {
            return _context.GerechtSoorten.Any(e => e.Id == id);
        }
    }
}
