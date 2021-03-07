using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class Assessment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Pontuação")]
        public int Punctuation { get; set; }
        [Display(Name = "Comentário")]
        public String Comment { get; set; }
        [Required]
        [Display(Name = "Usuário")]
        public virtual Login Login { get; set; }
        [Required]
        [Display(Name = "Oferta")]
        public virtual Offer Offer { get; set; }
        [Display(Name = "Status")]
        public char Active { get; set; }

    }
}