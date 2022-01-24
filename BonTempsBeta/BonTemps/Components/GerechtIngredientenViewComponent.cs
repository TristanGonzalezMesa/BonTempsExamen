using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BonTemps.Data;

namespace BonTemps.Components
{
    public class GerechtIngredientenViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public GerechtIngredientenViewComponent(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var ingredient = await _context.GerechtIngredienten //Data types uit de models halen
                .Include(vs => vs.Ingredient)
                .Where(d => d.GerechtId == id)
                .ToListAsync();

            return View(ingredient);
        }
    }
}