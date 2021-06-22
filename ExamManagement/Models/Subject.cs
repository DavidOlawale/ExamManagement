using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required, MaxLength(20), MinLength(3)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public virtual IEnumerable<CourseSubject> SubjectCourses { get; set; }
    }
}
