using BiletiApp.Domain.DomainModels;
using BiletiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}
