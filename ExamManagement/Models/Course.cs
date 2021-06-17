﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required, MaxLength(20), MinLength(3)]
        public string Name { get; set; }
        public virtual CourseSubject CourseSubject { get; set; }


    }
}
