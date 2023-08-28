using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class Registration
    {
        [Key]
        public int Registration_Id { get; set; }
        public DateTime Registration_Date { get; set; }
        public string Student_Id { get; set; }
        public string Course_Id { get; set; }
        public Student Student { get; set; }
        public Courses Courses { get; set; }
    }
}
