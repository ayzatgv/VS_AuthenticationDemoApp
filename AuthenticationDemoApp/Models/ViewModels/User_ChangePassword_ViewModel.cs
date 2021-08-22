using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemoApp.Models.ViewModels
{
    public class User_ChangePassword_ViewModel
    {
        #region Variables

        private string _oldPassword;
        private string _newPassword;

        #endregion

        #region Properties

        [Required]
        public string OldPassword
        {
            get { return _oldPassword; }
            set { _oldPassword = value; }
        }
        [Required]
        public string NewPassword
        {
            get { return _newPassword; }
            set { _newPassword = value; }
        }

        #endregion
    }
}