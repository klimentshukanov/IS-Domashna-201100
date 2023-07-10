using BiletiApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<CustomUser> GetAll();
        CustomUser Get(string id);
        void Insert(CustomUser entity);
        void Update(CustomUser entity);
        void Delete(CustomUser entity);
    }
}
