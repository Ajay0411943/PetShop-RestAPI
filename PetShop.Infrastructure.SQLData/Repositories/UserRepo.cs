using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQLData.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly PetShopContext _ctx;

        public UserRepo(PetShopContext context)
        {
            _ctx = context;
        }
        public IEnumerable<User> GetUsers()
        {
            return _ctx.Users;
        }

        public void UpdateUser(User user)
        {
            _ctx.Attach(user).State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
