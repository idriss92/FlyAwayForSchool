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
    
    public partial class Reservations
    {
        public int IdReservation { get; set; }
        public System.DateTime DateReservation { get; set; }
        public int TarifReservation { get; set; }
        public int IdVol { get; set; }
    
        public virtual Vols Vols { get; set; }
    }
}
