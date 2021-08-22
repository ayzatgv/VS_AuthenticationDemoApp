using System;
using System.Collections.Generic;
using System.Data;

namespace AuthenticationDemoApp.Models
{
    public class Wishlist
    {
        #region Variables

        private User _user;
        private Book _book;

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

        #endregion

        #region Constructors

        public Wishlist()
        {
            User = new User();
            Book = new Book();
        }

        #endregion

        #region Methodes

        public static List<Wishlist> Convert(DataTable dataTable)
        {
            List<Wishlist> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Wishlist>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Wishlist Convert(DataRow dataRow)
        {
            Wishlist result = null;

            if (dataRow != null)
            {
                result = new Wishlist();

                if (dataRow.Table.Columns.Contains("BookID") && dataRow["BookID"] != DBNull.Value)
                    result.Book.ID = System.Convert.ToInt32(dataRow["BookID"]);
                if (dataRow.Table.Columns.Contains("Title") && dataRow["Title"] != DBNull.Value)
                    result.Book.Title = System.Convert.ToString(dataRow["Title"]);
                if (dataRow.Table.Columns.Contains("Description") && dataRow["Description"] != DBNull.Value)
                    result.Book.Description = System.Convert.ToString(dataRow["Description"]);
                if (dataRow.Table.Columns.Contains("Pages") && dataRow["Pages"] != DBNull.Value)
                    result.Book.Pages = System.Convert.ToInt32(dataRow["Pages"]);
            }
            return result;
        }

        #endregion
    }
}