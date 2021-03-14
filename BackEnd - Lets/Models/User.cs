using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd___Lets.Models
{
    public class User
    {
        public int Type { get; set; }
        [Required(ErrorMessage ="Login obrigatório")]
        public string login { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Senha obrigatória")]
        public string senha { get; set; }
    }
}
