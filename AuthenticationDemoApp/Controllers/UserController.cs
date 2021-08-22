using AuthenticationDemoApp.DataAccess;
using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using AuthenticationDemoApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Web.Http;

namespace AuthenticationDemoApp.Controllers
{
    [MyAuthorize]
    public class UserController : ApiController
    {
        #region Post

        /// <summary>
        /// call this api for user registration
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Post([FromBody]User_Insert_ViewModel viewModel)
        {
            try
            {
                int returnValue = UserService.Users_Insert(viewModel.ConvertToModel());

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
        /// call this api for user logging in
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Login([FromBody]User_Login_ViewModel viewModel)
        {
            try
            {
                List<User> users = UserService.Users_Select(username: viewModel.Username);
                if (users == null || users.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2304)[0];
                    return BadRequest(error.Message);
                }

                User user = users[0];

                viewModel.Password = user.HashedPassword(viewModel.Password);
                if (user.Password != viewModel.Password)
                {
                    Error error = ErrorService.Errors_Select(2305)[0];
                    return BadRequest(error.Message);
                }

                user.Token = MyToken.TokenGeneration(user);
                UserService.Users_Update(user);

                return Ok(user.Token);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api to verify email
        /// </summary>
        /// <param name="code">verification code sent by email</param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public IHttpActionResult EmailVerification(string code)
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            User user = UserService.Users_Select(MyToken.GetUserID(token))[0];

            if (user.EmailVerificationPin != code)
            {
                Error error = ErrorService.Errors_Select(2306)[0];
                return BadRequest(error.Message);
            }

            user.EmailVerified = true;
            UserService.Users_Update(user);

            return Ok();
        }

        #endregion

        #region Get

        /// <summary>
        /// [REQUIRES TOKEN] call this api to get user's own infromation
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            User_Select_ViewModel viewModel = new User_Select_ViewModel(UserService.Users_Select(MyToken.GetUserID(token))[0]);

            return Ok(viewModel);
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api to get list of users infromation
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<User> users = UserService.Users_Select();
                List<User_Select_ViewModel> viewModels = new List<User_Select_ViewModel>();

                foreach (User user in users)
                {
                    if (user != null)
                        viewModels.Add(new User_Select_ViewModel(user));
                }

                return Ok(viewModels);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api to check for user authentication
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public IHttpActionResult Check()
        {
            return Ok();
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api to logout
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public IHttpActionResult Logout()
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            ClaimsPrincipal claimsPrincipal = MyToken.TokenDecryption(token);

            User user = UserService.Users_Select(Convert.ToInt32(claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value))[0];

            user.Token = null;

            UserService.Users_Update(user);

            return Ok();
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api to get emailverification pin
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public IHttpActionResult EmailVerification()
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            User user = UserService.Users_Select(MyToken.GetUserID(token))[0];
            user.EmailVerificationPin = Guid.NewGuid().ToString("N");

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("ayzatgv@gmail.com", "njngneuxetdgjxsn")
            };
            client.Send("ayzatgv@gmail.com", user.Email, "EmailVerification", user.EmailVerificationPin);
            client.Dispose();

            UserService.Users_Update(user);

            return Ok();
        }

        #endregion

        #region Put

        /// <summary>
        /// [REQUIRES TOKEN] call this api to edit user's own infromation
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>
        /// </returns>
        [HttpPut]
        public IHttpActionResult Put([FromBody]User_Update_ViewModel viewModel)
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                User user = UserService.Users_Select(MyToken.GetUserID(token))[0];

                user.Firstname = viewModel.Firstname;
                user.Lastname = viewModel.Lastname;
                user.Username = viewModel.Username;
                user.Email = viewModel.Email;

                int returnValue = UserService.Users_Update(user);

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
        /// [REQUIRES TOKEN] call this api to change user's password
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>
        /// </returns>
        [HttpPut]
        public IHttpActionResult ChangePassword([FromBody]User_ChangePassword_ViewModel viewModel)
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                User user = UserService.Users_Select(MyToken.GetUserID(token))[0];

                viewModel.OldPassword = user.HashedPassword(viewModel.OldPassword);
                if (user.Password != viewModel.OldPassword)
                {
                    Error error = ErrorService.Errors_Select(2305)[0];
                    return BadRequest(error.Message);
                }

                user.Password = user.HashedPassword(viewModel.NewPassword);
                UserService.Users_Update(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// [REQUIRES TOKEN] call this api to delete user' own account
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpDelete]
        public IHttpActionResult Delete()
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            User user = UserService.Users_Select(MyToken.GetUserID(token))[0];

            user.DeActivate = true;

            int returnValue = UserService.Users_Update(user);

            if (returnValue != 0)
            {
                Error error = ErrorService.Errors_Select(returnValue)[0];
                return BadRequest(error.Message);
            }

            return Ok();
        }

        #endregion
    }
}
