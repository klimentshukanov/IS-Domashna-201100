using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Domain.DomainModels
{
    public class Bilet : BaseEntity
    {
        //public Guid BiletId { get; set; }
        public string Ime { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public int BrDostapni { get; set; } 
        public DateTime Datum { get; set; }

    }
}
