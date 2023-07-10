using BiletiApp.Domain.Identity;
using BiletiApp.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        //public Guid OrderId { get; set; }

        public string UserId { get; set; }

        public CustomUser User { get; set; }

        public virtual ICollection<BiletOrder> BiletiOrders { get; set; }

    }
}
