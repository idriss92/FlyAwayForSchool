using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyAwayForSchool.Models
{
    public class ReservationModel
    {
        public VolModel Vol { get; set; }
        public int NbrePassagers { get; set; }
        public int TarifTotal { get; set; }
    }
}