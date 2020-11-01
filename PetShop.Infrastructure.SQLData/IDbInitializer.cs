using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQLData
{
   public interface IDBInitializer
    {
        void Seed(PetShopContext ctx);
    }
}
