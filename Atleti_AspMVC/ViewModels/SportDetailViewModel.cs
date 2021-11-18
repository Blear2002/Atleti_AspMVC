using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Atleti_AspMVC.Models;
namespace Atleti_AspMVC.ViewModels
{
    public class SportDetailViewModel
    {
        public string Title { get; set; }
        public Sport Sport { get; set; }
    }
}