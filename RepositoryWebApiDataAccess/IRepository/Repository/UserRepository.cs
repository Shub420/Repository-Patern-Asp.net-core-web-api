using RepositoryWebApiDataAccess.Data;
using RepositoryWebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiDataAccess.IRepository.Repository
{
   public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (userInDb == null)
                return null;
            userInDb.Password = "";
            return userInDb;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _context.Users.FirstOrDefault(p => p.UserName == username);
            if (user == null)
                return true;
            else
                return false;
        }

        public User Register(string username, string password)
        {
            User user = new User()
            {
                UserName = username,
                Password = password,
                Role = "Admin"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
