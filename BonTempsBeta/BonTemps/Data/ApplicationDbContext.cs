using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BonTemps.Models;

namespace BonTemps.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Klant> Klant { get; set; }
        public DbSet<Gerecht> Gerechten { get; set; } // Models Aanroepen
        public DbSet<GerechtIngredient> GerechtIngredienten { get; set; }
        public DbSet<GerechtSoort> GerechtSoorten { get; set; }
        public DbSet<Ingredient> Ingredienten { get; set; }
        public DbSet<MenuGerecht> MenuGerechten { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }
        public DbSet<ReserveringMenu> ReserveringMenus { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //Tussentabellen met de sleutels

            builder.Entity<GerechtIngredient>()
                .HasKey(vs => new { vs.GerechtId, vs.IngredientId });

            builder.Entity<MenuGerecht>()
                .HasKey(vs => new { vs.MenuId, vs.GerechtId });

            builder.Entity<ReserveringMenu>()
                .HasKey(vs => new { vs.ReserveringId, vs.MenuId });

            builder.Entity<Menu>().Property(m => m.Prijs).HasPrecision(18, 2);



         builder.Entity<Klant>()
        .HasData(
               new Klant
               {
                   Id = 1,
                   Voornaam = "Test",
                   Achternaam = "Achtermaam",
                   Straat = "Straat",
                   Huisnummer = 10,
                   Postcode = "341232",
                   Residence = "Niks",
                   Email = "test@test.nl",
                   Telefoonnummer = "74933493843"

               }
               );

         builder.Entity<Gerecht>()
        .HasData(
            new Gerecht
            {
                Id = 1,
                GerechtSoortId = 1,
                Naam = "Vlees"
            }
            );
        builder.Entity<Reservering>()
       .HasData(
           new Reservering
           {
               Id = 1,
               KlantId = 1
           }
           );
        builder.Entity<Menu>()
      .HasData(
        new Menu
        {
            Id = 1,
            Naam = "Diner",
            Prijs = 20
        }
        );
        builder.Entity<Ingredient>()
        .HasData(
        new Ingredient
        {
            Id = 1,
            Naam = "Sinas",
            Eenheid = "50ml"
        }
        );
        builder.Entity<GerechtSoort>()
        .HasData(
        new GerechtSoort
        {
            Id = 1,
            Soort = "Frisdrank",
        }
        );
        builder.Entity<ReserveringMenu>()
        .HasData(
   new ReserveringMenu
   {
       ReserveringId = 1,
       MenuId = 1,
       Aantal = 2
   }
   );
        }
    }
}
