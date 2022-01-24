using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class FactuurViewModel
    {
        public int Id { get; set; }
        public List<ReserveringMenu> Reserveringen { get; set; }
        public int TotaalAantal { get; set; }
        public decimal TotaalPrijsExBTW { get; set; }
        public decimal TotaalPrijs { get; set; }
        public decimal BTW { get; set; }

        public FactuurViewModel()
        {
            Reserveringen = new List<ReserveringMenu>();

        }

    }
}
