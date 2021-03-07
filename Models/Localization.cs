using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class Localization
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "CEP")]
        public String CEP { get; set; }
        [Display(Name = "Logradouro")]
        public String PublicPlace { get; set; }
        [Display(Name = "Número")]
        public String Number { get; set; }
        [Display(Name = "Complemento")]
        public String Complement { get; set; }
        [Display(Name = "UF")]
        public String State { get; set; }
        [Display(Name = "Cidade")]
        public String City { get; set; }
        [Display(Name = "Bairro")]
        public String Neighborhood { get; set; }
        [Display(Name = "Longitude")]
        public Double Longitude { get; set; }
        [Display(Name = "Latitude")]
        public Double Latitude { get; set; }
        [Display(Name = "Status")]
        public char Active { get; set; }    
    }
}
