using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AuthenticationDemoApp.DataAccess
{
    public class BookService : MyDataAccess
    {
        #region Select

        public static List<Book> Books_Select(int id = 0)
        {
            SqlCommand sqlCommand = GetCommand("Books_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);

            DataTable dataTable;
            List<Book> books;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                books = Book.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return books;
        }

        #endregion

        #region Insert

        public static int Books_Insert(Book book)
        {

            SqlCommand sqlCommand = GetCommand("Books_Insert");

            SqlParameter _title = new SqlParameter("@Title", SqlDbType.NVarChar, 64);
            SqlParameter _description = new SqlParameter("@Description", SqlDbType.NVarChar, -1);
            SqlParameter _author = new SqlParameter("@Author", SqlDbType.NVarChar, 64);
            SqlParameter _type = new SqlParameter("@Type", SqlDbType.NVarChar, 64);
            SqlParameter _pages = new SqlParameter("@Pages", SqlDbType.Int);
            SqlParameter _rating = new SqlParameter("@Rating", SqlDbType.Int);
            SqlParameter _total = new SqlParameter("@Total", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (!string.IsNullOrEmpty(book.Title))
                    _title.Value = book.Title;
                else
                    _title.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(book.Description))
                    _description.Value = book.Description;
                else
                    _description.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(book.Author))
                    _author.Value = book.Author;
                else
                    _author.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(book.Type))
                    _type.Value = book.Type;
                else
                    _type.Value = DBNull.Value;
                if (book.Pages != 0)
                    _pages.Value = book.Pages;
                else
                    _pages.Value = DBNull.Value;
                if (book.Rating != 0)
                    _rating.Value = book.Rating;
                else
                    _rating.Value = DBNull.Value;
                if (book.Total != 0)
                    _total.Value = book.Total;
                else
                    _total.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_title);
                sqlCommand.Parameters.Add(_description);
                sqlCommand.Parameters.Add(_author);
                sqlCommand.Parameters.Add(_type);
                sqlCommand.Parameters.Add(_pages);
                sqlCommand.Parameters.Add(_rating);
                sqlCommand.Parameters.Add(_total);
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

        public static int Books_Update(Book book)
        {
            SqlCommand sqlCommand = GetCommand("Books_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _title = new SqlParameter("@Title", SqlDbType.NVarChar, 64);
            SqlParameter _description = new SqlParameter("@Description", SqlDbType.NVarChar, -1);
            SqlParameter _author = new SqlParameter("@Author", SqlDbType.NVarChar, 64);
            SqlParameter _type = new SqlParameter("@Type", SqlDbType.NVarChar, 64);
            SqlParameter _pages = new SqlParameter("@Pages", SqlDbType.Int);
            SqlParameter _rating = new SqlParameter("@Rating", SqlDbType.Int);
            SqlParameter _total = new SqlParameter("@Total", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (book.ID != 0)
                    _id.Value = book.ID;
                else
                    _id.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(book.Title))
                    _title.Value = book.Title;
                else
                    _title.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(book.Description))
                    _description.Value = book.Description;
                else
                    _description.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(book.Author))
                    _author.Value = book.Author;
                else
                    _author.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(book.Type))
                    _type.Value = book.Type;
                else
                    _type.Value = DBNull.Value;
                if (book.Pages != 0)
                    _pages.Value = book.Pages;
                else
                    _pages.Value = DBNull.Value;
                if (book.Rating != 0)
                    _rating.Value = book.Rating;
                else
                    _rating.Value = DBNull.Value;
                if (book.Total != 0)
                    _total.Value = book.Total;
                else
                    _total.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_title);
                sqlCommand.Parameters.Add(_description);
                sqlCommand.Parameters.Add(_author);
                sqlCommand.Parameters.Add(_type);
                sqlCommand.Parameters.Add(_pages);
                sqlCommand.Parameters.Add(_rating);
                sqlCommand.Parameters.Add(_total);
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

        public static int Books_Delete(int id)
        {
            SqlCommand sqlCommand = GetCommand("Books_Delete");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
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