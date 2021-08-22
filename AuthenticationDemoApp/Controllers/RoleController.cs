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
    public class RoleController : ApiController
    {
        /// <summary>
        /// call this api get roles list
        /// </summary>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Role> roles = RoleService.Roles_Select();
                if (roles == null || roles.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2313)[0];
                    return BadRequest(error.Message);
                }


                return Ok(roles);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        /// call this api to get role's information
        /// </summary>
        /// <param name="id">role's id in database</param>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {

            try
            {
                List<Role> roles = RoleService.Roles_Select(id);
                if (roles == null || roles.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2313)[0];
                    return BadRequest(error.Message);
                }

                return Ok(roles[0]);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api to create new role
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public IHttpActionResult Post(Role_Post_ViewModel viewModel)
        {
            Role role = new Role();
            role.Access = viewModel.Access;

            int returnValue = RoleService.Roles_Insert(role);

            if (returnValue != 0)
            {
                Error error = ErrorService.Errors_Select(returnValue)[0];
                return BadRequest(error.Message);
            }

            return Ok();
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api to edit a role
        /// </summary>
        /// <param name="id">role's id in database</param>
        /// <param name="access">role's new name</param>
        /// <returns>
        /// </returns>
        [HttpPut]
        public IHttpActionResult Put(int id, string access)
        {
            try
            {
                List<Role> roles = RoleService.Roles_Select(id);
                if (roles == null || roles.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2313)[0];
                    return BadRequest(error.Message);
                }

                Role role = roles[0];
                role.Access = access;

                int returnValue = RoleService.Roles_Update(role);

                if (returnValue != 0)
                {
                    Error error = ErrorService.Errors_Select(returnValue)[0];
                    return BadRequest(error.Message);
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        /// [REQUIRES TOKEN]  call this api to delete a role
        /// </summary>
        /// <param name="id">role id in database</param>
        /// <returns>
        /// </returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            int returnValue = RoleService.Roles_Delete(id);

            if (returnValue != 0)
            {
                Error error = ErrorService.Errors_Select(returnValue)[0];
                return BadRequest(error.Message);
            }

            return Ok();
        }
    }
}
