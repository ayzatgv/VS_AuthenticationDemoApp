using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;

namespace AuthenticationDemoApp.Models
{
    public class User
    {
        #region Variables

        private int _id;
        private string _firstname;
        private string _lastname;
        private string _username;
        private string _passwordSalt;
        private string _password;
        private string _email;
        private bool _emailVerified;
        private string _emailVerificationPin;
        private string _token;
        private bool _deActivate;

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
        public string PasswordSalt
        {
            get { return _passwordSalt; }
            set { _passwordSalt = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
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
        public string EmailVerificationPin
        {
            get { return _emailVerificationPin; }
            set { _emailVerificationPin = value; }
        }
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public bool DeActivate
        {
            get { return _deActivate; }
            set { _deActivate = value; }
        }

        #endregion

        #region Constructors

        public User()
        {

        }
        public User(string firstname, string lastname, string username, string password, string email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            PasswordSalt = Guid.NewGuid().ToString("N");
            Password = HashedPassword(password);
            Email = email;
        }
        public User(int id, string firstname, string lastname, string username, string passwordSalt, string password, string email, bool emailVerified, string emailVerificationPin, string token, bool deActivate)
        {
            ID = id;
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            PasswordSalt = passwordSalt;
            Password = password;
            Email = email;
            EmailVerified = emailVerified;
            EmailVerificationPin = emailVerificationPin;
            Token = token;
            DeActivate = deActivate;
        }

        #endregion

        #region Methodes

        public static List<User> Convert(DataTable dataTable)
        {
            List<User> users = new List<User>();

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    users.Add(Convert(item));
                }
            }
            return users;
        }
        public static User Convert(DataRow dataRow)
        {
            User user = null;

            if (dataRow != null)
            {
                user = new User();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    user.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Firstname") && dataRow["Firstname"] != DBNull.Value)
                    user.Firstname = System.Convert.ToString(dataRow["Firstname"]);
                if (dataRow.Table.Columns.Contains("Lastname") && dataRow["Lastname"] != DBNull.Value)
                    user.Lastname = System.Convert.ToString(dataRow["Lastname"]);
                if (dataRow.Table.Columns.Contains("Username") && dataRow["Username"] != DBNull.Value)
                    user.Username = System.Convert.ToString(dataRow["Username"]);
                if (dataRow.Table.Columns.Contains("PasswordSalt") && dataRow["PasswordSalt"] != DBNull.Value)
                    user.PasswordSalt = System.Convert.ToString(dataRow["PasswordSalt"]);
                if (dataRow.Table.Columns.Contains("Password") && dataRow["Password"] != DBNull.Value)
                    user.Password = System.Convert.ToString(dataRow["Password"]);
                if (dataRow.Table.Columns.Contains("Email") && dataRow["Email"] != DBNull.Value)
                    user.Email = System.Convert.ToString(dataRow["Email"]);
                if (dataRow.Table.Columns.Contains("EmailVerified") && dataRow["EmailVerified"] != DBNull.Value)
                    user.EmailVerified = System.Convert.ToBoolean(dataRow["EmailVerified"]);
                if (dataRow.Table.Columns.Contains("EmailVerificationPin") && dataRow["EmailVerificationPin"] != DBNull.Value)
                    user.EmailVerificationPin = System.Convert.ToString(dataRow["EmailVerificationPin"]);
                if (dataRow.Table.Columns.Contains("Token") && dataRow["Token"] != DBNull.Value)
                    user.Token = System.Convert.ToString(dataRow["Token"]);
                if (dataRow.Table.Columns.Contains("DeActivate") && dataRow["DeActivate"] != DBNull.Value)
                    user.DeActivate = System.Convert.ToBoolean(dataRow["DeActivate"]);
            }
            return user;
        }
        public string HashedPassword(string password)
        {
            var saltedPassword = password + PasswordSalt;
            var saltedPasswordByBytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
            return System.Convert.ToBase64String(SHA512.Create().ComputeHash(saltedPasswordByBytes));
        }

        #endregion
    }
}