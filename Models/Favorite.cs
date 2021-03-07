using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class Favorite
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Oferta")]
        public virtual Offer Offer { get; set; }
        [Display(Name = "Usuário")]
        public virtual Login Login { get; set; }
        [Display(Name = "Status")]
        public char Active { get; set; }
    }
}