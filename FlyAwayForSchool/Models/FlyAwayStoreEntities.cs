using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlyAwayForSchool.Models
{
    public class FlyAwayStoreEntities : DbContext
    {
        public DbSet<VolModel> Vols { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
    }
}