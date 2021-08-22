using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AuthenticationDemoApp.DataAccess
{
    public class WishlistService : MyDataAccess
    {
        #region Select

        public static List<Wishlist> Wishlists_Select(int userID = 0)
        {
            SqlCommand sqlCommand = GetCommand("Wishlists_Select");

            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);

            DataTable dataTable;
            List<Wishlist> wishlists;
            try
            {
                if (userID != 0)
                    _userID.Value = userID;
                else
                    _userID.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_userID);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                wishlists = Wishlist.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return wishlists;
        }

        #endregion

        #region Insert

        public static int Wishlists_Insert(Wishlist wishlist)
        {
            SqlCommand sqlCommand = GetCommand("Wishlists_Insert");

            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter _bookID = new SqlParameter("@BookID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (wishlist.User.ID != 0)
                    _userID.Value = wishlist.User.ID;
                else
                    _userID.Value = DBNull.Value;
                if (wishlist.Book.ID != 0)
                    _bookID.Value = wishlist.Book.ID;
                else
                    _bookID.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_userID);
                sqlCommand.Parameters.Add(_bookID);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }

        #endregion

        #region Delete

        public static int Wishlists_Delete(Wishlist wishlist)
        {
            SqlCommand sqlCommand = GetCommand("Wishlists_Delete");

            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter _bookID = new SqlParameter("@BookID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (wishlist.User.ID != 0)
                    _userID.Value = wishlist.User.ID;
                else
                    _userID.Value = DBNull.Value;
                if (wishlist.Book.ID != 0)
                    _bookID.Value = wishlist.Book.ID;
                else
                    _bookID.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_userID);
                sqlCommand.Parameters.Add(_bookID);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }

        #endregion
    }
}