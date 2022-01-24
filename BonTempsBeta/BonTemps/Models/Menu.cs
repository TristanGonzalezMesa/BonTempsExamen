using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Menu
    {
        public Menu()
        {
            ReserveringMenu = new HashSet<ReserveringMenu>();
            MenuGerecht = new HashSet<MenuGerecht>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(40)]
        public string Naam { get; set; }
        [RegularExpression(@"^\d+(.\d{1,2})?$")] //Kijken hoe ik Decimal 18.2 hierin kan toevoegen ipv 19. (Gaf een error)
        public decimal Prijs { get; set; }
        public ICollection<ReserveringMenu> ReserveringMenu { get; set; }
        public ICollection<MenuGerecht> MenuGerecht { get; set; }
    }
}