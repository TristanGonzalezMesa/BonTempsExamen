using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BonTemps.Data;

namespace BonTemps.Components
{
    public class MenuGerechtenViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public MenuGerechtenViewComponent(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var gerecht = await _context.MenuGerechten //Data types uit de models halen
                .Include(vs => vs.Gerecht)
                .Where(d => d.MenuId == id)
                .ToListAsync();

            return View(gerecht);
        }
    }
}