using BlazorApp1.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDepartmentCoursesController : ControllerBase
    {
        private readonly DataContext _context;

        public GetDepartmentCoursesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetDepartmentCourses(string college, string department)
        {

            var deptCourses = await _context.AllCourses
                .Where(course =>  course.College == college && course.Department == department)
                .ToListAsync();

            return Ok(deptCourses);

        }

    }
}
