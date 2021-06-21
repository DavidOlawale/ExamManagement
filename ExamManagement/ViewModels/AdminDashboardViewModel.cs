using ExamManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.ViewModels
{
    public class AdminDashboardViewModel
    {
        public IdentityUser User { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
