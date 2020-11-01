using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
   public interface IUserServices
    {
        Tuple<string, string> ValidateUser(Tuple<string, string> attemptToLogin);

        List<User> GetAllUsers();
    }
}
