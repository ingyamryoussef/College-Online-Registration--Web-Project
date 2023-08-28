using BlazorApp1.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectCourseController : ControllerBase
    {
        private readonly DataContext _context;
        public SelectCourseController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetDepartmentCourses(string college, string department, string name)
        {
            var selectedCourse = await _context.AllCourses
                .Where(course => course.College == college && course.Department == department && course.Name==name)
                .ToListAsync();

            return Ok(selectedCourse[0]);
        }

    }
}
