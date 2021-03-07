using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class Image
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nome do arquivo")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Extensão do arquivo")]
        public String Extension { get; set; }
        [Display(Name = "Status")]
        public char Active { get; set; }
    }
}
