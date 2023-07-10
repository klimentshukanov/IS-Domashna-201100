using BiletiApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Domain.Relations
{
    public class BiletShoppingCart : BaseEntity
    {
        //public Guid Id { get; set; }
        public Guid BiletId { get; set; }
        public virtual Bilet Bilet { get; set; }

        public Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}
