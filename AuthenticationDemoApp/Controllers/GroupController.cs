using AuthenticationDemoApp.DataAccess;
using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using AuthenticationDemoApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AuthenticationDemoApp.Controllers
{
    [MyAuthorize]
    public class GroupController : ApiController
    {
        /// <summary>
        /// call this api to get groups' list
        /// </summary>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Group_Select_ViewModel> viewModels = new List<Group_Select_ViewModel>();

                List<Group> groups = GroupService.Groups_Select();
                List<Panel> panels = PanelService.Panels_Select();

                if (groups == null || groups.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2317)[0];
                    return BadRequest(error.Message);
                }

                foreach (var panel in panels)
                {
                    Group_Select_ViewModel temp = new Group_Select_ViewModel();
                    temp.Panel = panel;
                    viewModels.Add(temp);
                }

                foreach (var group in groups)
                {
                    foreach (var viewModel in viewModels)
                    {
                        if (viewModel.Panel.ID == group.Panel.ID)
                        {
                            viewModel.Menus.Add(group.Menu);
                        }
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
        /// call this api to get group's menu list
        /// </summary>
        /// <param name="id">panel's id in database</param>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Group_Select_ViewModel viewModel = new Group_Select_ViewModel();

                List<Group> groups = GroupService.Groups_Select(panelID: id);
                Panel panel = PanelService.Panels_Select(id)[0];

                if (groups == null || groups.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2317)[0];
                    return BadRequest(error.Message);
                }

                viewModel.Panel = panel;

                foreach (var group in groups)
                {
                    viewModel.Menus.Add(group.Menu);
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
