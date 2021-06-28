

using ExamManagement.Controllers;
using ExamManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public void CreateNofification(NotificationType notificationType, string message, string title = null)
        {
            var notification = new NotificationModel
            {
                Message = message,
                Title = title,
                Type = notificationType.ToString().ToLower()
            };

            JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
            };
            TempData["Notification"] = JsonConvert.SerializeObject(notification, settings);
        }
    }

}
