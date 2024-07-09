using ARSPracticeEMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace ARSPracticeEMS.Repository
{
    public interface IDepartmentRepository
    {
        Task<ActionResult<IEnumerable<Department>>> AllDepartments();
    }
}