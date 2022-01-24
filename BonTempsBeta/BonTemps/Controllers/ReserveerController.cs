using BonTemps.Data;
using BonTemps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Controllers
{
    public class ReserveerController : Controller
    {
        private ApplicationDbContext db;

        public ReserveerController(ApplicationDbContext _db)
        {
            db = _db;
        }

        // Reserveren stap 1
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Klant Klant, DateTime Datum, int AantalPersonen, Reservering reservering)
        {
            if (ModelState.IsValid)
            {
                db.Klant.Add(Klant);
                db.Reserveringen.Add(new Reservering() { Klant = Klant, Tijd = Datum.Add(Klant.Time.TimeOfDay), Datum = Datum, AantalPersonen = AantalPersonen });
                await db.SaveChangesAsync();
                return RedirectToAction("gelukt", new { Id = reservering.Id });
            }
            return View(Klant);
        }

        public IActionResult menukeuze(int Id)
        {
           
            var output = db.Reserveringen.Find(Id);

            ViewData["Reservering"] = db.Reserveringen.Find(Id);


            ViewData["ReserveringMenu"] = new SelectList(db.Menus, "Id", "Naam");


            return View(output);
        }

        [HttpPost]
        public async Task<IActionResult> menukeuze(List<Menu> List)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }

        public IActionResult Gelukt()
        {
            return View();
        }

    }
}

