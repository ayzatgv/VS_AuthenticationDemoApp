using AuthenticationDemoApp.DataAccess;
using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using AuthenticationDemoApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace AuthenticationDemoApp.Controllers
{
    [MyAuthorize]
    public class AllowController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ای دی رول در دیتابیس</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            List<Allow_Select_ViewModel> viewModels = new List<Allow_Select_ViewModel>();
            try
            {
                List<Panel> panels = PanelService.Panels_Select();
                foreach (var panel in panels)
                {
                    viewModels.Add(new Allow_Select_ViewModel(panel));
                }

                List<Allow> allows = AllowService.Allows_Select(roleID: id);
                if (allows == null || allows.Count == 0)
                    return Ok(viewModels);


                foreach (var allow in allows)
                {
                    foreach (var viewModel in viewModels)
                    {
                        if (allow.Panel.ID == viewModel.ID)
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
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post(int id, Allow_Select_ViewModel[] viewModels)
        {
            Allow allow = new Allow();
            allow.Role.ID = id;

            foreach (var viewModel in viewModels)
            {
                allow.Panel.ID = viewModel.ID;
                if (viewModel.Status == false)
                    AllowService.Allows_Delete(allow);
                if (viewModel.Status == true)
                    AllowService.Allows_Insert(allow);
            }

            return Ok();
        }

        /// <summary>
        /// با دادن توکن دریافت دسترسی های کاربر به پنل ها بصورت بولین
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Check()
        {
            Allow_Check_ViewModel viewModel = new Allow_Check_ViewModel();

            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                List<Permission> permissions = PermissionService.Permissions_Select(MyToken.GetUserID(token));
                if (permissions == null || permissions.Count == 0)
                    return Ok(viewModel);

                List<Allow> allows = AllowService.Allows_Select();

                foreach (var permission in permissions)
                {
                    foreach (var allow in allows)
                    {
                        if (allow.Role.ID == permission.Role.ID)
                        {
                            if (nameof(viewModel.HandleBook) == allow.Panel.Name)
                                viewModel.HandleBook = true;
                            if (nameof(viewModel.HandleCategory) == allow.Panel.Name)
                                viewModel.HandleCategory = true;
                            if (nameof(viewModel.HandleBorrow) == allow.Panel.Name)
                                viewModel.HandleBorrow = true;
                            if (nameof(viewModel.HandleRole) == allow.Panel.Name)
                                viewModel.HandleRole = true;
                        }
                    }
                }

                return Ok(viewModel);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
    }
}
