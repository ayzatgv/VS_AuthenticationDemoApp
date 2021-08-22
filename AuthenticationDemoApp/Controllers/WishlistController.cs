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
    public class WishlistController : ApiController
    {
        #region Post

        /// <summary>
        /// [REQUIRES TOKEN] call this api to add book to user's wishlist
        /// </summary>
        /// <param name="id">id of the book to add to wishlist</param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public IHttpActionResult Post(int id)
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            Wishlist wishlist = new Wishlist();
            wishlist.User.ID = MyToken.GetUserID(token);
            wishlist.Book.ID = id;

            int returnValue = WishlistService.Wishlists_Insert(wishlist);
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
        /// [REQUIRES TOKEN] call this api to get user's wishlist
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            List<Wishlist_Select_ViewModel> viewModels = new List<Wishlist_Select_ViewModel>();

            try
            {
                List<Wishlist> wishlists = WishlistService.Wishlists_Select(MyToken.GetUserID(token));

                if (wishlists == null || wishlists.Count == 0)
                {
                    Error error = ErrorService.Errors_Select(2309)[0];
                    return BadRequest(error.Message);
                }

                foreach (var wishlist in wishlists)
                {
                    viewModels.Add(new Wishlist_Select_ViewModel(wishlist));
                }
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
            return Ok(viewModels);
        }

        #endregion

        #region Delete

        /// <summary>
        /// [REQUIRES TOKEN] call this api to delete book from user's wishlist
        /// </summary>
        /// <param name="id">book id in database</param>
        /// <returns>
        /// </returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            string token = (ActionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? ActionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            Wishlist wishlist = new Wishlist();
            wishlist.User.ID = MyToken.GetUserID(token);
            wishlist.Book.ID = id;

            int returnValue = WishlistService.Wishlists_Delete(wishlist);

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
