using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ExamManagement.Models
{
    [Table("Students")]
    public class Student : IdentityUser
    {
        [Required, MinLength(3), MaxLength(15), Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(15), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public virtual IEnumerable<StudentCourse> StudentCourses { get; set; }
        public virtual IEnumerable<ExamScheduleEnrollment> ExamScheduleEnrollments { get; set; }
    }
}
