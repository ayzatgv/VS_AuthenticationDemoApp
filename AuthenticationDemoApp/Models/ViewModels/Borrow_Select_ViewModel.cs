using System;

namespace AuthenticationDemoApp.Models.ViewModels
{
    public class Borrow_Select_ViewModel
    {
        #region Variables

        private int _userID;
        private string _username;
        private string _email;
        private int _bookID;
        private string _title;
        private string _writer;
        private string _subject;
        private DateTime _borrowedAt;
        private DateTime _returnedAt;
        private DateTime _expiresAt;
        private bool _returned;

        #endregion

        #region Properties

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
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
        public string Writer
        {
            get { return _writer; }
            set { _writer = value; }
        }
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
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

        public Borrow_Select_ViewModel()
        {

        }

        public Borrow_Select_ViewModel(Borrow borrow)
        {
            this.UserID = borrow.User.ID;
            this.Username = borrow.User.Username;
            this.Email = borrow.User.Email;
            this.BookID = borrow.Book.ID;
            this.Title = borrow.Book.Title;
            this.Writer = borrow.Book.Author;
            this.Subject = borrow.Book.Type;
            this.BorrowedAt = borrow.BorrowedAt;
            if (borrow.ReturnedAt != null)
                this.ReturnedAt = borrow.ReturnedAt;
            this.ExpiresAt = borrow.ExpiresAt;
            this.Returned = borrow.Returned;
        }

        #endregion
    }
}