using BiletiApp.Domain.DomainModels;
using BiletiApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Domain.Relations
{
    public class BiletOrder : BaseEntity
    {
        //public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public Guid BiletId { get; set; }

        public Bilet Bilet { get; set; }

        public int quantity;


    }
}
