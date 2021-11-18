using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atleti_AspMVC.Models
{
    public class UserLoginData
    {                   
        [Required(ErrorMessage = "Campo obbligatorio")]
        [MinLength(5,ErrorMessage = "Lunghezza minima di almeno 5 caratteri")]
        [MaxLength(255)]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Campo obbligatorio")]
        [MinLength(4,ErrorMessage = "Lunghezza minima di almeno 4 carattere")]
        [MaxLength(1024)]
        public string Password { get; set; }


    }
}