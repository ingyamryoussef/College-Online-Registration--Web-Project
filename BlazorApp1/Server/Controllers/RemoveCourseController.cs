using BlazorApp1.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveCourseController : ControllerBase
    {
        private readonly DataContext _context;

        public RemoveCourseController(DataContext context)
        {
            _context = context;
        }
        //[HttpGet]
        [HttpDelete("{studentId}/{courseId}")]
        public async Task<ActionResult> RemoveCourse(string studentId,string courseId)
        {
            var exists = _context.Registrations.Any(r => r.Course_Id == courseId && r.Student_Id == studentId);
            if (exists) { 
            var _courseToRemove = await _context.Registrations
                .Where(r=>r.Course_Id == courseId && r.Student_Id == studentId)
                .ToListAsync();
                _context.Registrations.Remove(_courseToRemove[0]);
                _context.SaveChanges();
                Console.WriteLine("\nREMOVED COURSE");
                 return Ok("Removed");
            }
            else
            {
                Console.WriteLine("\nNOT REMOVED");
                return Ok("not removed");
            }

            
        }
    }
}
