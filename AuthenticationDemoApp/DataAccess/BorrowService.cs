using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AuthenticationDemoApp.DataAccess
{
    public class BorrowService : MyDataAccess
    {
        #region Select

        public static List<Borrow> Borrows_Select(int userID = 0)
        {
            SqlCommand sqlCommand = GetCommand("Borrows_Select");

            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);

            DataTable dataTable;
            List<Borrow> borrows;
            try
            {
                if (userID != 0)
                    _userID.Value = userID;
                else
                    _userID.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_userID);

                dataTable= GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                borrows = Borrow.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return borrows;
        }

        #endregion

        #region Insert

        public static int Borrows_Insert(Borrow borrow)
        {

            SqlCommand sqlCommand = GetCommand("Borrows_Insert");

            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter _bookID = new SqlParameter("@BookID", SqlDbType.Int);
            SqlParameter _borrowedAt = new SqlParameter("@BorrowedAt", SqlDbType.DateTime);
            SqlParameter _expiresAt = new SqlParameter("@ExpiresAt", SqlDbType.DateTime);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (borrow.User.ID != 0)
                    _userID.Value = borrow.User.ID;
                else
                    _userID.Value = DBNull.Value;
                if (borrow.Book.ID != 0)
                    _bookID.Value = borrow.Book.ID;
                else
                    _bookID.Value = DBNull.Value;
                if (borrow.BorrowedAt != null)
                    _borrowedAt.Value = borrow.BorrowedAt;
                else
                    _borrowedAt.Value = DBNull.Value;
                if (borrow.ExpiresAt != null)
                    _expiresAt.Value = borrow.ExpiresAt;
                else
                    _expiresAt.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_userID);
                sqlCommand.Parameters.Add(_bookID);
                sqlCommand.Parameters.Add(_borrowedAt);
                sqlCommand.Parameters.Add(_expiresAt);
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

        #region Update

        public static int Borrows_Update(Borrow borrow)
        {
            SqlCommand sqlCommand = GetCommand("Borrows_Update");

            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter _bookID = new SqlParameter("@BookID", SqlDbType.Int);
            SqlParameter _returnedAt = new SqlParameter("@ReturnedAt", SqlDbType.DateTime);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (borrow.User.ID != 0)
                    _userID.Value = borrow.User.ID;
                else
                    _userID.Value = DBNull.Value;
                if (borrow.Book.ID != 0)
                    _bookID.Value = borrow.Book.ID;
                else
                    _bookID.Value = DBNull.Value;
                if (borrow.ReturnedAt != null)
                    _returnedAt.Value = borrow.ReturnedAt;
                else
                    _returnedAt.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_userID);
                sqlCommand.Parameters.Add(_bookID);
                sqlCommand.Parameters.Add(_returnedAt);
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