using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class People
    {
        [Display(Name ="Celular")]
        [DataType(DataType.PhoneNumber)]
        public String Cell { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
    }
}
