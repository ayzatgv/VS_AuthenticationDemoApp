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
    public class BorrowController : ApiController
    {
        /// <summary>
        /// [REQUIRES TOKEN] call this api to get user's borrowed books list
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            try
            {
                List<Borrow> borrows = BorrowService.Borrows_Select(MyToken.GetUserID(token));
                if (borrows == null || borrows.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2321)[0];
                    return BadRequest(error.Message);
                }

                List<Borrow_Select_ViewModel> viewModels = new List<Borrow_Select_ViewModel>();
                foreach (var borrow in borrows)
                {
                    viewModels.Add(new Borrow_Select_ViewModel(borrow));
                }

                return Ok(viewModels);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api for admin to get all borrowed books list
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<Borrow> borrows = BorrowService.Borrows_Select();
                if (borrows == null || borrows.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2321)[0];
                    return BadRequest(error.Message);
                }

                List<Borrow_Select_ViewModel> viewModels = new List<Borrow_Select_ViewModel>();
                foreach (var borrow in borrows)
                {
                    viewModels.Add(new Borrow_Select_ViewModel(borrow));
                }

                return Ok(viewModels);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api to borrow a book for user
        /// </summary>
        /// <param name="id">book's id in database you want to borrow</param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public IHttpActionResult Post(int id)
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            List<Book> books = BookService.Books_Select(id);
            if (books==null || books.Count==0)
            {
                Error error = ErrorService.Errors_Select(2322)[0];
                return BadRequest(error.Message);
            }

            Borrow borrow = new Borrow();
            borrow.User.ID = MyToken.GetUserID(token);
            borrow.Book.ID = id;
            borrow.BorrowedAt = DateTime.Now;
            borrow.ExpiresAt = DateTime.Now.AddMinutes(5);

            int returnValue = BorrowService.Borrows_Insert(borrow);

            if (returnValue != 0)
            {
                Error error = ErrorService.Errors_Select(returnValue)[0];
                return BadRequest(error.Message);
            }

            return Ok();
        }

        /// <summary>
        /// [REQUIRES TOKEN] call this api to return a borrowed book
        /// </summary>
        /// <param name="id">book's id in the database</param>
        /// <returns>
        /// </returns>
        [HttpPut]
        public IHttpActionResult Put(int id)
        {
            try
            {
                string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

                Borrow borrow = new Borrow();
                borrow.User.ID = MyToken.GetUserID(token);
                borrow.Book.ID = id;
                borrow.ReturnedAt = DateTime.Now;

                int returnValue = BorrowService.Borrows_Update(borrow);

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
    }
}
