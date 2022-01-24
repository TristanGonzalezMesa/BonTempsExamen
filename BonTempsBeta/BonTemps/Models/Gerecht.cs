using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Gerecht
    {
        public Gerecht()
        {
            GerechtIngredient = new HashSet<GerechtIngredient>();
            MenuGerecht = new HashSet<MenuGerecht>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(80)]

        public string Naam { get; set; }

        //Relatie met GerechtSoort
        [ForeignKey("GerechtSoort")]
        [Display(Name = "GerechtSoort")]
        public int GerechtSoortId { get; set; }

        public ICollection<GerechtIngredient> GerechtIngredient { get; set; }
        public ICollection<MenuGerecht> MenuGerecht { get; set; }
    }
}
