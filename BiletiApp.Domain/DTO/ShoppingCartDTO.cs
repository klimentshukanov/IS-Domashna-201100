using BiletiApp.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public List<BiletShoppingCart> Bileti { get; set; }

        public double TotalPrice { get; set; }
    }
}
