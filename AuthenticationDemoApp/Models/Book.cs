using System;
using System.Collections.Generic;
using System.Data;

namespace AuthenticationDemoApp.Models
{
    public class Book
    {
        #region Variables

        private int _id;
        private string _title;
        private string _description;
        private string _author;
        private string _type;
        private int _pages;
        private int _rating;
        private int _total;
        private int _borrowed;

        #endregion

        #region Properties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
        public int Borrowed
        {
            get { return _borrowed; }
            set { _borrowed = value; }
        }
        

        #endregion

        #region Constructors

        public Book()
        {
        }

        #endregion

        #region Methodes

        public static List<Book> Convert(DataTable dataTable)
        {
            List<Book> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Book>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Book Convert(DataRow dataRow)
        {
            Book result = null;

            if (dataRow != null)
            {
                result = new Book();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Title") && dataRow["Title"] != DBNull.Value)
                    result.Title = System.Convert.ToString(dataRow["Title"]);
                if (dataRow.Table.Columns.Contains("Description") && dataRow["Description"] != DBNull.Value)
                    result.Description = System.Convert.ToString(dataRow["Description"]);
                if (dataRow.Table.Columns.Contains("Author") && dataRow["Author"] != DBNull.Value)
                    result.Author = System.Convert.ToString(dataRow["Author"]);
                if (dataRow.Table.Columns.Contains("Type") && dataRow["Type"] != DBNull.Value)
                    result.Type = System.Convert.ToString(dataRow["Type"]);
                if (dataRow.Table.Columns.Contains("Pages") && dataRow["Pages"] != DBNull.Value)
                    result.Pages = System.Convert.ToInt32(dataRow["Pages"]);
                if (dataRow.Table.Columns.Contains("Rating") && dataRow["Rating"] != DBNull.Value)
                    result.Rating = System.Convert.ToInt32(dataRow["Rating"]);
                if (dataRow.Table.Columns.Contains("Total") && dataRow["Total"] != DBNull.Value)
                    result.Total = System.Convert.ToInt32(dataRow["Total"]);
                if (dataRow.Table.Columns.Contains("Borrowed") && dataRow["Borrowed"] != DBNull.Value)
                    result.Borrowed = System.Convert.ToInt32(dataRow["Borrowed"]);
            }
            return result;
        }

        #endregion
    }
}