using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class MenuGerecht
    {
        [ForeignKey("Menu")]
        [Display(Name = "Menu")]
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        [ForeignKey("Gerecht")]
        [Display(Name = "Gerecht")]
        public int GerechtId { get; set; }
        public virtual Gerecht Gerecht { get; set; }

    }
}