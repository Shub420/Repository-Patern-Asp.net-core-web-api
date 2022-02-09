using RepositoryWebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiDataAccess.IRepository
{
  public  interface IEmployeeRepository:IRepository<Employee>
    {
        bool update(Employee employee);
    }

}
