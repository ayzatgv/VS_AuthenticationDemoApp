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
    public class PanelController : ApiController
    {
        /// <summary>
        /// call this api to get panels' detail list
        /// </summary>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Panel> panels = PanelService.Panels_Select();
                if (panels == null || panels.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2314)[0];
                    return BadRequest(error.Message);
                }


                return Ok(panels);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        /// call this api to get panel's detail
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
                List<Panel> panels = PanelService.Panels_Select(id);
                if (panels == null || panels.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2315)[0];
                    return BadRequest(error.Message);
                }

                return Ok(panels[0]);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }
    }
}
