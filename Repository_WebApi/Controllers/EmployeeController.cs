using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryWebApiBussinessLayer.DTOs;
using RepositoryWebApiBussinessLayer.Services.IServices;
using RepositoryWebApiDataAccess.IRepository;
using RepositoryWebApiDataAccess.IRepository.Repository;
using RepositoryWebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_WebApi.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "EmpDoc")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;
        //public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //}
        /// <summary>
        /// Get All Employees 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var empList = _employeeService.GetAll();
            return Ok(empList);
        }

        /// <summary>
        /// Add New Employee
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreateEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(StatusCodes.Status500InternalServerError);
            var emp = _employeeService.Add(employeeDto);
            return Ok(emp);
           
           
        }

        /// <summary>
        /// Get individual employee by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            if (id == 0)
                return BadRequest();
            var status=_employeeService.Get(id);
            return Ok(status);            
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [HttpPatch(Name = "UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null)
                return BadRequest(StatusCodes.Status500InternalServerError);
            if (!ModelState.IsValid)
                return BadRequest();
            var emp = _employeeService.Update(employeeDto);
            return Ok(emp);

        }
        /// <summary>
        /// To Delete individual employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpDelete("{empId:int}")]
        public IActionResult Delete(int empId)
        {
            if (empId == 0)
                return BadRequest(StatusCodes.Status500InternalServerError);
            var empDel = _employeeService.Remove(empId);
            return Ok(empDel);
        }

    }
}
