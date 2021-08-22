namespace AuthenticationDemoApp.Models.ViewModels
{
    public class Book_Update_ViewModel
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

        #endregion
    }
}