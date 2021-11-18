using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atleti_AspMVC.Models
{
    public class AthleteSearch
    {
        [Required(ErrorMessage = "Campo obbligatorio, scrivere il nome dell'Atleta")]
        public string Name { get; set; }
    }
}