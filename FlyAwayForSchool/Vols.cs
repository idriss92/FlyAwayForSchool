//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlyAwayForSchool
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vols
    {
        public Vols()
        {
            this.Reservations = new HashSet<Reservations>();
        }
    
        public int Id { get; set; }
        public string Depart { get; set; }
        public string Arrivee { get; set; }
        public System.DateTime DateDepart { get; set; }
        public System.DateTime DateArrivee { get; set; }
        public Nullable<int> Distance { get; set; }
        public Nullable<int> Prix { get; set; }
        public string HeureDepart { get; set; }
        public string HeureArrivee { get; set; }
        public Nullable<int> Passagers { get; set; }
        public string PolitiqueName { get; set; }
    
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
