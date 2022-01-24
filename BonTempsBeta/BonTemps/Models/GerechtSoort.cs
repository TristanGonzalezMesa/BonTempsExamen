using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class GerechtSoort
    {
        public int Id { get; set; }
        [StringLength(80)]
        public string Soort { get; set; }
    }
}
