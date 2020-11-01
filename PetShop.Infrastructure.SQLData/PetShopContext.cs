using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQLData
{
    public class PetShopContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; } 
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users{ get; set; }

        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt)
        {

        }
    }
}
