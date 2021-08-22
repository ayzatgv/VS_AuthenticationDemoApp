using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemoApp.Models.ViewModels
{
    public class Book_Insert_ViewModel
    {
        #region Variables

        private string _title;
        private string _description;
        private string _author;
        private string _type;
        private int _pages;
        private int _rating;
        private int _total;

        #endregion

        #region Properties

        [Required]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        [Required]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        [Required]
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        [Required]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        [Required]
        public int Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }
        [Required]
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
        [Required]
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        #endregion

        #region Methodes

        public Book ConvertToModel()
        {
            Book book = new Book();

            if (!string.IsNullOrEmpty(this.Title))
                book.Title = this.Title;
            if (!string.IsNullOrEmpty(this.Description))
                book.Description = this.Description;
            if (!string.IsNullOrEmpty(this.Author))
                book.Author = this.Author;
            if (!string.IsNullOrEmpty(this.Type))
                book.Type = this.Type;
            if (this.Pages != 0)
                book.Pages = this.Pages;
            if (this.Rating != 0)
                book.Rating = this.Rating;
            if (this.Total != 0)
                book.Total = this.Total;

            return book;
        }

        #endregion
    }
}