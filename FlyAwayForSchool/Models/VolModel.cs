using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyAwayForSchool.Models
{
    public class VolModel
    {
        public string Depart {get;set;}
        public string Arrivee { get; set; }
        public DateTime DateDepart {get;set;}
        public DateTime DateArrivee { get; set; }
        public int Distance { get; set; }
        public int Prix { get; set; }
        public string  HeureDepat { get; set; }
        public string HeureArrivee { get; set; }
    }
}