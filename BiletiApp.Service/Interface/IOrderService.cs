using BiletiApp.Domain.DomainModels;
using BiletiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}
