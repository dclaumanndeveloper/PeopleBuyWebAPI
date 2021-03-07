using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class DailyOffer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public String Name { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Preço")]
        public float Price { get; set; }
        [Required]
        [Display(Name = "Unidade")]
        public String Unit { get; set; }
        [Display(Name = "Data Início")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name ="Data Fim")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public virtual Category Category { get; set; }
        
        [Display(Name = "Subcategoria")]
        public virtual SubCategory SubCategory { get; set; }
        [Display(Name = "Dia da semana")]
        public String DayWeek { get; set; }
        [Display(Name = "Razão Social")]
        public String CompanyName { get; set; }
        [Display(Name = "Localização")]
        public virtual Localization Localization { get; set; }
        [Display(Name = "Status")]
        public char Active { get; set; }
    }
}