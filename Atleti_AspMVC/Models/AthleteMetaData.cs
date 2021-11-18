using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atleti_AspMVC.Models
{
    public class AthleteMetaData
    {
        //vincoli -- come not null al momento dell'edit
        [Required(ErrorMessage = "Inserire qualcosa in questo campo")]
        [MinLength(1, ErrorMessage = "Minimo 1 carattere")]
        [MaxLength(6,ErrorMessage = "Massimo 6 caratteri")]
        [Key]
        [Display(Name = "Sesso")] //invece di mettere il nome da cshtml lo imposto già da qua così avremo il nome desiderato automaticamente        
        public string Sex { get; set; }

        [Required(ErrorMessage = "Il nome non può essere vuoto")]        
        public string Name { get; set; }
    }

    //classe atleti è composta da ciò che mi genere entity + ciò che aggiungo io
    //Classe atleti i tuoi attributi prendili da questo tipo di oggetto scritto qua sopra
    //In cui inserisce metadati solo per la proprietà Sex
    [MetadataType(typeof(AthleteMetaData))]
    public partial class Athlete
    {

    }
}