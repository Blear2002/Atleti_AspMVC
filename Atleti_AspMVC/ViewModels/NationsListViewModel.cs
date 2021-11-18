using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Atleti_AspMVC.Models;
namespace Atleti_AspMVC.ViewModels
{
    public class NationsListViewModel
    {
        public int Pages { get; set; }
        public int Page { get; set; }
        public List<Nationality> Nations { get; set; }
    }
}