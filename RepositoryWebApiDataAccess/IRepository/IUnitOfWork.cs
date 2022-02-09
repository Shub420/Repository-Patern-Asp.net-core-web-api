using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiDataAccess.IRepository
{
    public interface IUnitOfWork
    {
       public IEmployeeRepository employee { get; }
       public IUserRepository user { get; }
    }
}
