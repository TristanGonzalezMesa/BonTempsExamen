using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Reservering
    {
        public Reservering()
        {
            ReserveringMenu = new HashSet<ReserveringMenu>();
        }
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:H/mm}", ApplyFormatInEditMode = true)]
        public DateTime Tijd { get; set; }

        [ForeignKey("Klant")]
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public ICollection<ReserveringMenu> ReserveringMenu { get; set; }
        public int AantalPersonen { get; set; }
    }
}
