using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models
{
    public class Klant
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        public string Achternaam { get; set; }
        public string Naam => $"{Voornaam}{Achternaam}";

        [Required]
        public string Straat { get; set; }

        [Required]
        public int Huisnummer { get; set; }

        [Required]
        [MaxLength(6)]
        public string Postcode { get; set; }

        [Required]
        public string Residence { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telefoonnummer { get; set; }

        /* Propertys for model validation */
        [NotMapped]
        [Required]
        public int AantalPersonen { get; set; }

        [Required]
        [NotMapped]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
    }
}
