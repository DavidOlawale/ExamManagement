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
        [Required, MinLength(3), MaxLength(15)]
        public int FirstName { get; set; }

        [Required, MinLength(3), MaxLength(15)]
        public int LastName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public virtual IEnumerable<StudentCourse> StudentCourses { get; set; }
    }
}
