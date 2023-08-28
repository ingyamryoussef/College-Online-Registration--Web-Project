using BlazorApp1.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetRegisteredCoursesController : ControllerBase
    {
        private readonly DataContext _context;
        public string stringmessage = "";

        public GetRegisteredCoursesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetRegisteredCourses(string id,string pin)
        {
            
            var _registration = await _context.Registrations
                .Where(r => r.Student_Id == id)
                .ToListAsync();

            var courses = new List<Courses>();
            if (_registration!= null && _registration.Count>0) {
                stringmessage = stringmessage + "if is entered\n";
                foreach(var registration in _registration)
                {
                    var tempregid = registration.Course_Id;
                    stringmessage = stringmessage + "for each is entered\n";
                    // var _course = await _context.AllCourses
                    //    .Where(c => c.CourseId.ToString() == registration.Course_Id.ToString())
                    //   .ToListAsync();

                    var _course = await _context.AllCourses
                        .Where(c => c.CourseId == tempregid)
                        .ToListAsync();
                    var tempcourse = _course[0];
                    
                    if (tempcourse != null)
                     {
                        stringmessage = stringmessage + "a course is entered: " + tempcourse.CourseId+ "\n";
                         courses.Add(tempcourse);

                     }
                     else
                    {
                        stringmessage = stringmessage + "nothing was added\n";
                    }
                }
                
            }
            else
            {
                stringmessage = "ELSE IS ENTERED";
            }
            Console.WriteLine(courses + "PLEEEEEEEEEEEEEEEEEEEEEEEEEAAAAAAAAAAAASSSSSSSSSSSSSSSEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE\n"+stringmessage);
            return Ok(courses);
        }
    }
}
