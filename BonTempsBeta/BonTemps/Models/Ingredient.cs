using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            GerechtIngredient = new HashSet<GerechtIngredient>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string Naam { get; set; }
        [StringLength(20)]
        public string Eenheid { get; set; }
        public ICollection<GerechtIngredient> GerechtIngredient { get; set; }
    }
}
