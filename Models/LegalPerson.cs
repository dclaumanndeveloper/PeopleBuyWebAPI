using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class LegalPerson : People
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "CNPJ")]
        public String CNPJ { get; set; }
        [Required]
        [Display(Name = "Razão Social")]
        public String CompanyName { get; set; }
        [Display(Name = "Endereço")]
        public virtual Localization Localization { get; set; }
        [Display(Name = "Login")]
        public virtual Login Login { get; set; }
        [Display(Name = "Status")]
        public char Active { get; set; }
    }
}
