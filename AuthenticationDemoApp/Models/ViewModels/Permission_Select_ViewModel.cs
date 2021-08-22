namespace AuthenticationDemoApp.Models.ViewModels
{
    public class Permission_Select_ViewModel
    {
        private int _id;
        private string _username;
        private string _firstname;
        private string _lastname;
        private bool _status;

        /// <summary>
        /// ای دی یوزر در دیتابیس
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
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
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public Permission_Select_ViewModel()
        {

        }
        public Permission_Select_ViewModel(User user)
        {
            this.ID = user.ID;
            this.Username = user.Username;
            this.Firstname = user.Firstname;
            this.Lastname = user.Lastname;
            this.Status = false;
        }
    }
}