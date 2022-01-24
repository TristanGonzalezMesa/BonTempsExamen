using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BonTemps.Data;

namespace BonTemps.Components
{
    public class MenuReserveringenViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public MenuReserveringenViewComponent(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var menu = await _context.ReserveringMenus //Data types uit de models halen
                .Include(vs => vs.Menu)
                .Where(d => d.ReserveringId == id)
                .ToListAsync();

            return View(menu);
        }
    }
}
