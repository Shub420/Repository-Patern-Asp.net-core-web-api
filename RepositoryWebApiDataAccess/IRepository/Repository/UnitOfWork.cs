using RepositoryWebApiDataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiDataAccess.IRepository.Repository
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            employee = new EmployeeRepository(_context);
            user = new UserRepository(_context);

        }
        public IEmployeeRepository employee { get; private set; }

        public IUserRepository user { get; private set; }
    }
}
