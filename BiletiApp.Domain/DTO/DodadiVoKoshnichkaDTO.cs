using BiletiApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Domain.DTO
{
    public class DodadiVoKoshnichkaDTO
    {
        public Bilet SelektiranBilet { get; set; }
        public Guid SelektiranBiletId { get; set; }
        public int Quantity { get; set; }
    }
}
