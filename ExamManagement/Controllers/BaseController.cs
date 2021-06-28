using ExamManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExamManagement.Controllers
{
    [Authorize]
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

    

    public enum NotificationType
    {
        Success,
        Info,
        Warning,
        Error
    }

    public class NotificationModel
    {
        public string Title;
        public string Message;
        public string Type;

    }
}
