using BiletiApp.Domain.DomainModels;
using BiletiApp.Domain;
using BiletiApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BiletiApp.Repository.Interface;

namespace BiletiApp.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> getAllOrders()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.BiletiOrders)
                .Include("BiletiOrders.Bilet")
                .ToListAsync().Result;
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return entities
               .Include(z => z.User)
               .Include(z => z.BiletiOrders)
               .Include("BiletiOrders.Bilet")
               .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}
