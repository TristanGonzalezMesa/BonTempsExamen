using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class GerechtIngredient
    {
        //Relation met Gerecht
        [ForeignKey("Gerecht")]
        [Display(Name = "Gerecht")]
        public int GerechtId { get; set; }
        public virtual Gerecht Gerecht { get; set; }

        //Relation met Ingredient
        [ForeignKey("Ingredient")]
        [Display(Name = "Ingredient")]
        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        public int Aantal { get; set; }
    }
}