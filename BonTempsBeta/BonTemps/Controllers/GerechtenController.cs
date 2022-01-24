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
    public class GerechtenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerechtenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gerechten
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gerechten.ToListAsync());
        }

        // GET: Gerechten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["IngredientId"] = new SelectList(_context.Ingredienten, "Id", "Naam");

            if (id == null)
            {
                return NotFound();
            }

            var gerechten = await _context.Gerechten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerechten == null)
            {
                return NotFound();
            }

            return View(gerechten);
        }

        // GET: Gerechten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gerechten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GerechtSoortId,Naam")] Gerecht gerechten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerechten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gerechten);
        }

        // GET: Gerechten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechten = await _context.Gerechten.FindAsync(id);
            if (gerechten == null)
            {
                return NotFound();
            }
            return View(gerechten);
        }

        // POST: Gerechten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GerechtSoortId,Naam")] Gerecht gerechten)
        {
            if (id != gerechten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerechten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerechtenExists(gerechten.Id))
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
            return View(gerechten);
        }

        // GET: Gerechten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechten = await _context.Gerechten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerechten == null)
            {
                return NotFound();
            }

            return View(gerechten);
        }

        // POST: Gerechten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerechten = await _context.Gerechten.FindAsync(id);
            _context.Gerechten.Remove(gerechten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerechtenExists(int id)
        {
            return _context.Gerechten.Any(e => e.Id == id);
        }

        //POST Gerechten.AddGerecht
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredient(GerechtIngredient GerechtIngredient)
        {
            var existingGerechtIngredient = await _context.GerechtIngredienten
                .FindAsync(GerechtIngredient.GerechtId, GerechtIngredient.IngredientId);

            if (existingGerechtIngredient == null)
            {
                _context.Add(GerechtIngredient);
            }
            else
            {
                existingGerechtIngredient.Ingredient = GerechtIngredient.Ingredient;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = GerechtIngredient.GerechtId });
        }
    }
}
