using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class PhysicalPerson : People
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="CPF")]
        public String CPF { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public String Name { get; set; }
        public virtual Login Login { get; set; }
        [Display(Name = "Status")]
        public char Active { get; set; }
    }
}
