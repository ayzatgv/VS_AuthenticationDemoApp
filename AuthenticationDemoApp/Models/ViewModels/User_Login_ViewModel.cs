using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemoApp.Models.ViewModels
{
    public class User_Login_ViewModel
    {
        #region Variables

        private string _username;
        private string _password;

        #endregion

        #region Properties

        [Required]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        [Required]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        #endregion
    }
}