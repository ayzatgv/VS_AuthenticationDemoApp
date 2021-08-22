using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemoApp.Models.ViewModels
{
    public class User_Update_ViewModel
    {
        #region Variables

        private string _firstname;
        private string _lastname;
        private string _username;
        private string _email;

        #endregion

        #region Properties

        [Required]
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        [Required]
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        [Required]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        [Required]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        #endregion
    }
}