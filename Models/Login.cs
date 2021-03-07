using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class Login
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Usuário")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Numero de caracteres menor que ou maior que 100 ", MinimumLength = 6)]
        public String User { get; set; }
        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Numero de caracteres menor que ou maior que 100 ", MinimumLength = 6)]
        public String Password { get; set; }
        [Display(Name = "Tipo de Login")]
        public Enumerators.AccessType AccessType { get; set; }
        [Display(Name = "Status")]
        public char Active { get; set; }
    }
}