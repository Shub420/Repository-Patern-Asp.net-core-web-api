using RepositoryWebApiBussinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiBussinessLayer.Services.IServices
{
   public interface IEmployeeService
    {
        EmployeeDto Get(int Id);
        IEnumerable<EmployeeDto> GetAll();
        bool Add(EmployeeDto empDto);
        bool Remove(int Id);
        bool Update(EmployeeDto empDto);
    }
}
