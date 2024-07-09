using ARSPracticeEMS.Models;
using ARSPracticeEMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARSPracticeEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> AllDepartment()
        {
            return await _departmentRepository.AllDepartments();
         
        }
    }
}
