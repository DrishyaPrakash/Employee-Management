using ARSPracticeEMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace ARSPracticeEMS.Repository
{
    public interface IEmployeeRepository
    {
        Task<ActionResult<Employee>> AddEmployee(Employee employee);
        Task<ActionResult<IEnumerable<EmpDeptViewModel>>> AllEmployees();
        Task<ActionResult<bool>> EmployeeExistence(Employee emp);
    }
}