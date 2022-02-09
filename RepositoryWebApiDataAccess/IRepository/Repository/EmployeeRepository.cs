using RepositoryWebApiDataAccess.Data;
using RepositoryWebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiDataAccess.IRepository.Repository
{
  public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public bool update(Employee employee)
        {
            _context.Update(employee);
            return Save();
        }
    }
}
