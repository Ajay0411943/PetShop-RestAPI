using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Impl
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepo _userRepo;
        private readonly IAuthentication _authentication;

        public UserServices(IUserRepo userRepo, IAuthentication authentication)
        {
            _userRepo = userRepo;
            _authentication = authentication;
        }


        public List<User> GetAllUsers()
        {
            return _userRepo.GetUsers().ToList();
        }

        public Tuple<string, string> ValidateUser(Tuple<string, string> attemptToLogin)
        {
            var user = _userRepo.GetUsers().ToList().FirstOrDefault(u =>u.Username == attemptToLogin.Item1);

            if (user == null)
            {
                throw new ArgumentException("Invalid User");
            }
            if(!_authentication.VerifyPasswordHash(attemptToLogin.Item2, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Invalid Password");
            }
            return new Tuple<string, string>(_authentication.GenerateToken(user), user.Username);
        }
    }
}
