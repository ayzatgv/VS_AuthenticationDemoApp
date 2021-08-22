namespace AuthenticationDemoApp.Models.ViewModels
{
    public class User_Select_ViewModel
    {
        #region Variables

        private int _id;
        private string _firstname;
        private string _lastname;
        private string _username;
        private string _email;
        private bool _emailVerified;

        #endregion

        #region Properties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
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
        public bool EmailVerified
        {
            get { return _emailVerified; }
            set { _emailVerified = value; }
        }

        #endregion

        #region Constructors

        public User_Select_ViewModel()
        {

        }

        public User_Select_ViewModel(User user)
        {
            this.ID = user.ID;
            this.Firstname = user.Firstname;
            this.Lastname = user.Lastname;
            this.Username = user.Username;
            this.Email = user.Email;
            this.EmailVerified = user.EmailVerified;
        }

        #endregion
    }
}