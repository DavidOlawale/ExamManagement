using ExamManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.ViewModels
{
    public class StudentRegisterViewModel
    {
        public Student Student { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password"), Display(Name ="Confirm Password")]

        public string ConfirmPassword { get; set; }

        public SelectList CourseSelectList { get; set; }

        [Required, Display(Name ="Course")]
        public int CourseId { get; set; }
    }
}
