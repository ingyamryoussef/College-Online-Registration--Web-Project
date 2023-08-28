using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class Courses
    {
        [Key]
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public string College { get; set; }
        public string Department { get; set; }
        public int Capacity { get; set; }
        public string Lecturer { get; set; }
        public string Instructor { get; set; }
        public string LectureTime { get; set; }
        public string SectionTime { get; set;}

        [JsonIgnore]
        public ICollection<Registration> Registrations { get; set; }

    }
}
