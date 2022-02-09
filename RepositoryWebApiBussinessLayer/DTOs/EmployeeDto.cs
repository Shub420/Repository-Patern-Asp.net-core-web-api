using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiBussinessLayer.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
    }
}
