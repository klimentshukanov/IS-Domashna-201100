using BiletiApp.Domain.DomainModels;
using BiletiApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Service.Interface
{
    public interface IBiletService
    {
        List<Bilet> ListajBileti();
        Bilet DetaliZaBilet(Guid? id);
        void KreirajBilet(Bilet p);
        void AzhurirajBilet(Bilet p);
        DodadiVoKoshnichkaDTO GetShoppingCartInfo(Guid? id);
        void IzbrishiBilet(Guid id);
        bool AddToShoppingCart(DodadiVoKoshnichkaDTO item, string userID);
    }
}
