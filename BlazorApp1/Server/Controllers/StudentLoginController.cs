using BlazorApp1.Server.Data;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentLoginController : ControllerBase
    {
        /*private static List<Student> _students = new List<Student>()
        {
            new Student { StudentId = "1", Pin = "123", Name = "John Doe", College = "Engineering", Department="Computer", CreditHours=18, IsRegistrationAvailable=true, Semester=2 },
            new Student { StudentId = "2", Pin = "456" , Name = "Jane Smith", College = "Engineering", Department="Architecture", CreditHours=36, IsRegistrationAvailable=true, Semester=3 }
        };*/
        private readonly DataContext _context;

        public StudentLoginController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetStudentLogin(string id, string pin)
        {
            
            if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pin))
            {
                return BadRequest();
            }
            var _students = await _context.Students
                .Where(s => s.StudentId == id)
                .ToListAsync();
            var student = _students[0];
            if (student != null && student.Pin == pin)
            {
                return Ok(student);
            }
            
            else
            {
                return Ok(new Student());
            }
            

        }
    }
}
