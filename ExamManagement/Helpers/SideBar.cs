using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace ExamManagement.Helpers
{
    public static class HtmlHelpers
    {
        public static string SideBarItemOpen(this IHtmlHelper htmlHelper, string controller, string action = null)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var routeController = routeData.Values["controller"].ToString();
            var routeAction = routeData.Values["action"].ToString();

            if (string.IsNullOrEmpty(action))
                return controller.Equals(routeController, StringComparison.OrdinalIgnoreCase) ? "menu-item-open menu-item-here" : string.Empty;

            return controller.Equals(routeController, StringComparison.OrdinalIgnoreCase) && action.Equals(routeAction, StringComparison.OrdinalIgnoreCase) ? "menu-item-open menu-item-here" : string.Empty;
        }

        public static string SideBarMenuItemActive(this IHtmlHelper htmlHelper, string controller, string action = null)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var routeController = routeData.Values["controller"].ToString();
            var routeAction = routeData.Values["action"].ToString();

            if (string.IsNullOrEmpty(action))
                return controller.Equals(routeController, StringComparison.OrdinalIgnoreCase) ? "menu-item-open menu-item-here" : string.Empty;

            return controller.Equals(routeController, StringComparison.OrdinalIgnoreCase) && action.Equals(routeAction, StringComparison.OrdinalIgnoreCase) ? "menu-item-active" : string.Empty;
        }
    }
}
