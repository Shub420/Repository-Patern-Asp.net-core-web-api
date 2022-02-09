using AutoMapper;
using RepositoryWebApiBussinessLayer.DTOs;
using RepositoryWebApiBussinessLayer.Services.IServices;
using RepositoryWebApiDataAccess.IRepository;
using RepositoryWebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWebApiBussinessLayer.Services
{
  public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool Add(EmployeeDto empDto)
        {
            if (empDto == null)
                return false;
            var employee = _mapper.Map<EmployeeDto, Employee>(empDto);
            if (!_unitOfWork.employee.Add(employee))
            {
                return false;
            }
            return true;
        }

        public EmployeeDto Get(int Id)
        {
            var emp = _unitOfWork.employee.Get(Id);
            if (emp == null)
                return null;
            var empDto = _mapper.Map<Employee, EmployeeDto>(emp);
            return empDto;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var empList = _unitOfWork.employee.GetAll().Select(_mapper.Map<Employee, EmployeeDto>);
            return empList;
        }

        public bool Remove(int empDto)
        {

            if (empDto == 0)
                return false;
            var emp = _unitOfWork.employee.Get(empDto);
            if (emp == null)
                return false;
            if (!_unitOfWork.employee.Remove(emp))
            {
                return false;
            }
            return true;
        }

       
        public bool Update(EmployeeDto empDto)
        {
            if (empDto == null)
                return false;
            var empDtos = _mapper.Map<EmployeeDto, Employee>(empDto);
            if (!_unitOfWork.employee.update(empDtos))
            {
                return false;
            }
            return true;
        }
    }
}
