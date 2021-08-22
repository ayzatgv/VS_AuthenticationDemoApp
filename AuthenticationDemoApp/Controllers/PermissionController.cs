using AuthenticationDemoApp.DataAccess;
using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using AuthenticationDemoApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace AuthenticationDemoApp.Controllers
{
    [MyAuthorize]
    public class PermissionController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ای دی رول ها در دیتابیس</param>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<Permission_Select_ViewModel> viewModels = new List<Permission_Select_ViewModel>();

            try
            {
                List<Models.User> users = UserService.Users_Select();
                foreach (var user in users)
                {
                    viewModels.Add(new Permission_Select_ViewModel(user));
                }

                List<Permission> permissions = PermissionService.Permissions_Select(roleID: id);
                if (permissions == null || permissions.Count == 0)
                    return Ok(viewModels);


                foreach (var viewModel in viewModels)
                {
                    foreach (var permission in permissions)
                    {
                        if (viewModel.ID == permission.User.ID)
                            viewModel.Status = true;
                    }
                }

                return Ok(viewModels);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ای دی رول در دیتابیس</param>
        /// <param name="viewModels"></param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public IHttpActionResult Post(int id, Permission_Select_ViewModel[] viewModels)
        {
            Permission permission = new Permission();
            permission.Role.ID = id;

            foreach (var viewModel in viewModels)
            {
                permission.User.ID = viewModel.ID;
                if (viewModel.Status == false)
                    PermissionService.Permissions_Delete(permission);
                if (viewModel.Status == true)
                    PermissionService.Permissions_Insert(permission);
            }

            return Ok();
        }
    }
}
