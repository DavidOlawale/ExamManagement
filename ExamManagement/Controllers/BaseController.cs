using ExamManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       protected ApplicationDbContext db;
    }
}
