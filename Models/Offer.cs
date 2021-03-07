using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class Offer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name ="Nome")]
        public String Name { get; set; }
    }
}
