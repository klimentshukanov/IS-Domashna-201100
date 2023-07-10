using BiletiApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDTO getShoppingCartInfo(string userId);
        bool izbrishiBiletOdShoppingCart(string userId, Guid biletId);
        //bool order(string userId);
    }
}
