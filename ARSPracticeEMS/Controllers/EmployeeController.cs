using ARSPracticeEMS.Models;
using ARSPracticeEMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ARSPracticeEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
       public EmployeeController(EmployeeRepository employeeRepository)
       {
            _employeeRepository = employeeRepository;
       }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpDeptViewModel>>> GetAllEmployee()
        {
            var employees = await _employeeRepository.AllEmployees();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            //await _employeeRepository.AddEmployee(employee);
            return await _employeeRepository.AddEmployee(employee);
        }

        [HttpGet("Existence")]
        public async Task<ActionResult> EmpExistence(Employee employee)
        {
            var existence= await _employeeRepository.EmployeeExistence(employee);
            return Ok(existence);
        }

    }
}
