using BlazorApp1.Server.Data;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeRegistrationController : ControllerBase
    {
        
        private readonly DataContext _context;

        public MakeRegistrationController(DataContext context)
        {
            _context = context;
        }

        private Student? student;
        private Courses? course;

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(JsonElement jsonstring)
        {
            /*//var jsonobject = JsonSerializer.Deserialize<JsonElement>(jsonstring);


            //JObject jsonobject = JObject.Parse($"{jsonstring}");

            foreach (var course in registrationPost.RegisterationCourses)
            {

                _conetxt.Registrations.Add(new Registration
                {
                    Registration_Id = 1,
                    Registration_Date = new DateTime(2018, 7, 1, 9, 0, 0),
                    Student_Id = registrationPost.RegistrationId,
                    Course_Id = course.CourseId
                }) ;
            }
            _conetxt.SaveChanges();
            //DateTime tempDate = new DateTime(2018, 7, 1, 9, 0, 0);
            //var reg_id = jsonobject.GetProperty("RegistrationId").GetString();
            //string jsonstring = JsonSerializer.Serialize(jsonobject, new JsonSerializerOptions { WriteIndented = true });
            //string reg_id = (string)jsonobject["RegistrationId"];
            
            student = new Student { StudentId = x[3] };
            course = new Courses { CourseId = x[7] };
            _conetxt.Registrations.Add(new Registration
            {
                
                Registration_Date = new DateTime(2018, 7, 1, 9, 0, 0),
                Student = student,
                Courses = course
            });
            _conetxt.SaveChanges();*/
            
            string[] x = $"{jsonstring}".Split('"');

            var _registration = await _context.Registrations
                .Where(r => r.Student_Id == x[3] && r.Course_Id == x[7])
                .ToListAsync();
            //var registration = _registration[0];
            var exists = _registration.Any(r => r.Student_Id == x[3] && r.Course_Id == x[7]);
            if(exists == false) { 
            _context.Registrations.Add(new Registration
            {
                Registration_Date = new DateTime(2018, 7, 1, 9, 0, 0),
                Student_Id = x[3],
                Course_Id = x[7]
            });
            _context.SaveChanges();
            
            Console.WriteLine("\nCourse " + x[7] + " is added\n");
            return Ok("Registered Successfully");
            }
            else
            {
                Console.WriteLine("\nCourse " + x[7] + " is NOT added\n");
                return Ok("Registered Before");
            }
        }
        
    }
}
