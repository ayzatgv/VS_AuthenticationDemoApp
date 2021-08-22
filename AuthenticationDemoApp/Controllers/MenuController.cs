using AuthenticationDemoApp.DataAccess;
using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
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
    public class MenuController : ApiController
    {
        /// <summary>
        /// call this api to get menus' detail
        /// </summary>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Menu> menus = MenuService.Menus_Select();
                if (menus == null || menus.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2316)[0];
                    return BadRequest(error.Message);
                }

                return Ok(menus);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
    }
}
