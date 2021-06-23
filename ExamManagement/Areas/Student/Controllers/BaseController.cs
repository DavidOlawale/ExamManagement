using ExamManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Areas.Student.Controllers
{
    [Authorize(Roles ="Student")]
    [Area("Student")]
    public class BaseController : Controller
    {
        protected ApplicationDbContext db;
    }
}
