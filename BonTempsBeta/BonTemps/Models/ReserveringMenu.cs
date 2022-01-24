using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class ReserveringMenu
    {
        //Relatie met Reservering
        [ForeignKey("Reservering")]
        [Display(Name = "Reservering")]
        public int ReserveringId { get; set; }
        public virtual Reservering Reservering { get; set; }

        //Relatie met Menu
        [ForeignKey("Menu")]
        [Display(Name = "Menu")]
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }

        public int Aantal { get; set; }
    }
}
