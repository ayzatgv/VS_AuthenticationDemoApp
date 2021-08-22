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
    public class BookController : ApiController
    {
        #region Post

        /// <summary>
        ///  call this api for book registration
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody]Book_Insert_ViewModel viewModel)
        {
            int returnValue = BookService.Books_Insert(viewModel.ConvertToModel());

            if (returnValue != 0)
            {
                Error error = ErrorService.Errors_Select(returnValue)[0];
                return BadRequest(error.Message);
            }

            return Ok();
        }

        #endregion

        #region Get

        /// <summary>
        ///  call this api to get books list
        /// </summary>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Book> books = BookService.Books_Select();
                if (books == null || books.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2323)[0];
                    return BadRequest(error.Message);
                }

                return Ok(books);

            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        /// <summary>
        ///  call this api to get book's infromation
        /// </summary>
        /// <param name="id">id of the book searching for</param>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                List<Book> books = BookService.Books_Select(id);
                if (books == null || books.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2324)[0];
                    return BadRequest(error.Message);
                }

                Book book = books[0];

                return Ok(book);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// [REQUIRES TOKEN] call this api to edit book's infromation
        /// </summary>
        /// <param name="id">book id in database</param>
        /// <param name="viewModel"></param>
        /// <returns>
        /// </returns>
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Book_Update_ViewModel viewModel)
        {
            try
            {
                List<Book> books = BookService.Books_Select(id);
                if (books == null || books.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2324)[0];
                    return BadRequest(error.Message);
                }

                Book book = books[0];

                book.Title = viewModel.Title;
                book.Description = viewModel.Description;
                book.Author = viewModel.Author;
                book.Type = viewModel.Type;
                book.Pages = viewModel.Pages;
                book.Rating = viewModel.Rating;
                book.Total = viewModel.Total;
                

                int returnValue = BookService.Books_Update(book);

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

        #endregion

        #region

        /// <summary>
        /// [REQUIRES TOKEN] call this api to delete book
        /// </summary>
        /// <param name="id">book's id in database</param>
        /// <returns>
        /// </returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            List<Book> books = BookService.Books_Select(id);
            if (books == null || books.Count == 0)
            {
                Error error = ErrorService.Errors_Select(2324)[0];
                return BadRequest(error.Message);
            }

            int returnValue = BookService.Books_Delete(id);

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
