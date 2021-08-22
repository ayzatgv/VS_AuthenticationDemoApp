using System;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemoApp.Models.ViewModels
{
    public class User_Insert_ViewModel
    {
        #region Variables

        private string _firstname;
        private string _lastname;
        private string _username;
        private string _password;
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
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [Required]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        #endregion

        #region Constructors

        #endregion

        #region Methodes

        public User ConvertToModel()
        {
            User user = new User();

            if (!string.IsNullOrEmpty(this.Firstname))
                user.Firstname = this.Firstname;
            if (!string.IsNullOrEmpty(this.Lastname))
                user.Lastname = this.Lastname;
            if (!string.IsNullOrEmpty(this.Username))
                user.Username = this.Username;
            if (!string.IsNullOrEmpty(this.Password))
            {
                user.PasswordSalt = Guid.NewGuid().ToString("N");
                user.Password = user.HashedPassword(this.Password);
            }
            if (!string.IsNullOrEmpty(this.Email))
                user.Email = this.Email;

            return user;
        }

        #endregion
    }
}