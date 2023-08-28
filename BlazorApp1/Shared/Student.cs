using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class Student
    {
        public string StudentId { get; set; }
        public string Pin { get; set; }
        public string Name { get; set; }
        public string College { get; set; }
        public string Department { get; set; }
        public int CreditHours { get; set; }
        public int Semester { get; set; }
        public bool IsRegistrationAvailable { get; set; }

        [JsonIgnore]
        public ICollection<Registration> Registrations { get; set; }

    }
}
