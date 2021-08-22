using AuthenticationDemoApp.DataAccess;
using AuthenticationDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace AuthenticationDemoApp.Helpers
{
    public class MyAuthorize : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string token = (actionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? actionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            string action = actionContext.ActionDescriptor.ActionName;
            string controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            try
            {
                if (!MyToken.TokenValidation(token))
                    return false;

                ClaimsPrincipal claimsPrincipal = MyToken.TokenDecryption(token);

                User user = UserService.Users_Select(Convert.ToInt32(claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value))[0];

                if (user.Token != token)
                    return false;

                List<Permission> permissions = PermissionService.Permissions_Select(Convert.ToInt32(claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));

                List<Menu> menus = MenuService.Menus_Select(controller: controller, action: action);
                if (menus == null || menus.Count == 0)
                    return true;
                Menu menu = menus[0];
                Group group = GroupService.Groups_Select(menuID: menu.ID)[0];
                List<Allow> allows = AllowService.Allows_Select(panelID: group.Panel.ID);

                foreach (var permission in permissions)
                {
                    foreach (var allow in allows)
                    {
                        if (allow.Role.ID == permission.Role.ID)
                            return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}