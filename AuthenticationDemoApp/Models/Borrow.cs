using System;
using System.Collections.Generic;
using System.Data;

namespace AuthenticationDemoApp.Models
{
    public class Borrow
    {
        #region Variables

        private User _user;
        private Book _book;
        private DateTime _borrowedAt;
        private DateTime _returnedAt;
        private DateTime _expiresAt;
        private bool _returned;

        #endregion

        #region Properties

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public Book Book
        {
            get { return _book; }
            set { _book = value; }
        }
        public DateTime BorrowedAt
        {
            get { return _borrowedAt; }
            set { _borrowedAt = value; }
        }
        public DateTime ReturnedAt
        {
            get { return _returnedAt; }
            set { _returnedAt = value; }
        }
        public DateTime ExpiresAt
        {
            get { return _expiresAt; }
            set { _expiresAt = value; }
        }
        public bool Returned
        {
            get { return _returned; }
            set { _returned = value; }
        }

        #endregion

        #region Constructors

        public Borrow()
        {
            User = new User();
            Book = new Book();
        }

        #endregion

        #region Methodes

        public static List<Borrow> Convert(DataTable dataTable)
        {
            List<Borrow> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Borrow>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Borrow Convert(DataRow dataRow)
        {
            Borrow result = null;

            if (dataRow != null)
            {
                result = new Borrow();

                if (dataRow.Table.Columns.Contains("UserID") && dataRow["UserID"] != DBNull.Value)
                    result.User.ID = System.Convert.ToInt32(dataRow["UserID"]);
                if (dataRow.Table.Columns.Contains("Username") && dataRow["Username"] != DBNull.Value)
                    result.User.Username = System.Convert.ToString(dataRow["Username"]);
                if (dataRow.Table.Columns.Contains("Email") && dataRow["Email"] != DBNull.Value)
                    result.User.Email = System.Convert.ToString(dataRow["Email"]);
                if (dataRow.Table.Columns.Contains("BookID") && dataRow["BookID"] != DBNull.Value)
                    result.Book.ID = System.Convert.ToInt32(dataRow["BookID"]);
                if (dataRow.Table.Columns.Contains("Title") && dataRow["Title"] != DBNull.Value)
                    result.Book.Title = System.Convert.ToString(dataRow["Title"]);
                if (dataRow.Table.Columns.Contains("Author") && dataRow["Author"] != DBNull.Value)
                    result.Book.Author = System.Convert.ToString(dataRow["Author"]);
                if (dataRow.Table.Columns.Contains("Type") && dataRow["Type"] != DBNull.Value)
                    result.Book.Type = System.Convert.ToString(dataRow["Type"]);
                if (dataRow.Table.Columns.Contains("BorrowedAt") && dataRow["BorrowedAt"] != DBNull.Value)
                    result.BorrowedAt = System.Convert.ToDateTime(dataRow["BorrowedAt"]);
                if (dataRow.Table.Columns.Contains("ReturnedAt") && dataRow["ReturnedAt"] != DBNull.Value)
                    result.ReturnedAt = System.Convert.ToDateTime(dataRow["ReturnedAt"]);
                if (dataRow.Table.Columns.Contains("ExpiresAt") && dataRow["ExpiresAt"] != DBNull.Value)
                    result.ExpiresAt = System.Convert.ToDateTime(dataRow["ExpiresAt"]);
                if (dataRow.Table.Columns.Contains("Returned") && dataRow["Returned"] != DBNull.Value)
                    result.Returned = System.Convert.ToBoolean(dataRow["Returned"]);
            }
            return result;
        }

        #endregion
    }
}