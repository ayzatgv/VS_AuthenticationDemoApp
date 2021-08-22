namespace AuthenticationDemoApp.Models.ViewModels
{
    public class Wishlist_Select_ViewModel
    {
        #region Variables

        private int _bookID;
        private string _title;
        private string _description;
        private int _pages;

        #endregion

        #region Properties

        public int BookID
        {
            get { return _bookID; }
            set { _bookID = value; }
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
        public int Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }

        #endregion

        #region Constructors

        public Wishlist_Select_ViewModel()
        {

        }

        public Wishlist_Select_ViewModel(Wishlist wishlist)
        {
            this.BookID = wishlist.Book.ID;
            this.Title = wishlist.Book.Title;
            this.Description = wishlist.Book.Description;
            this.Pages = wishlist.Book.Pages;
        }

        #endregion
    }
}