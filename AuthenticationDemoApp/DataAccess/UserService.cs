using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AuthenticationDemoApp.DataAccess
{
    public class UserService : MyDataAccess
    {
        #region Select

        public static List<User> Users_Select(int id = 0, string username = null, string email=null)
        {
            SqlCommand sqlCommand = GetCommand("Users_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 64);
            SqlParameter _email = new SqlParameter("@Email", SqlDbType.NVarChar, 256);

            DataTable dataTable;
            List<User> users;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(username))
                    _username.Value = username;
                else
                    _username.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(email))
                    _email.Value = email;
                else
                    _email.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_username);
                sqlCommand.Parameters.Add(_email);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                users = User.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return users;
        }

        #endregion

        #region Insert

        public static int Users_Insert(User user)
        {

            SqlCommand sqlCommand = GetCommand("Users_Insert");

            SqlParameter _firstname = new SqlParameter("@Firstname", SqlDbType.NVarChar, 64);
            SqlParameter _lastname = new SqlParameter("@Lastname", SqlDbType.NVarChar, 64);
            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 64);
            SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 256);
            SqlParameter _passwordSalt = new SqlParameter("@PasswordSalt", SqlDbType.NVarChar, 128);
            SqlParameter _email = new SqlParameter("@Email", SqlDbType.NVarChar, 256);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (!string.IsNullOrEmpty(user.Firstname))
                    _firstname.Value = user.Firstname;
                else
                    _firstname.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Lastname))
                    _lastname.Value = user.Lastname;
                else
                    _lastname.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Username))
                    _username.Value = user.Username;
                else
                    _username.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Password))
                    _password.Value = user.Password;
                else
                    _password.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.PasswordSalt))
                    _passwordSalt.Value = user.PasswordSalt;
                else
                    _passwordSalt.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Email))
                    _email.Value = user.Email;
                else
                    _email.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_firstname);
                sqlCommand.Parameters.Add(_lastname);
                sqlCommand.Parameters.Add(_username);
                sqlCommand.Parameters.Add(_password);
                sqlCommand.Parameters.Add(_passwordSalt);
                sqlCommand.Parameters.Add(_email);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }

            return (int)_result.Value;
        }

        #endregion

        #region Update

        public static int Users_Update(User user)
        {
            SqlCommand sqlCommand = GetCommand("Users_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _firstname = new SqlParameter("@FirstName", SqlDbType.NVarChar, 64);
            SqlParameter _lastname = new SqlParameter("@LastName", SqlDbType.NVarChar, 64);
            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 64);
            SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 256);
            SqlParameter _email = new SqlParameter("@Email", SqlDbType.NVarChar, 256);
            SqlParameter _emailVerified = new SqlParameter("@EmailVerified", SqlDbType.Bit);
            SqlParameter _emailVerificationPin = new SqlParameter("@EmailVerificationPin", SqlDbType.NVarChar, 128);
            SqlParameter _token = new SqlParameter("@Token", SqlDbType.NVarChar, 512);
            SqlParameter _deActivate = new SqlParameter("@DeActivate", SqlDbType.Bit);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (user.ID != 0)
                    _id.Value = user.ID;
                else
                    _id.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(user.Firstname))
                    _firstname.Value = user.Firstname;
                else
                    _firstname.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Lastname))
                    _lastname.Value = user.Lastname;
                else
                    _lastname.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Username))
                    _username.Value = user.Username;
                else
                    _username.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Password))
                    _password.Value = user.Password;
                else
                    _password.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(user.Email))
                    _email.Value = user.Email;
                else
                    _email.Value = DBNull.Value;
                if (user.EmailVerified)
                    _emailVerified.Value = 1;
                else
                    _emailVerified.Value = 0;
                if (!string.IsNullOrEmpty(user.EmailVerificationPin))
                    _emailVerificationPin.Value = user.EmailVerificationPin;
                else
                    _emailVerificationPin.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(user.Token))
                    _token.Value = user.Token;
                else
                    _token.Value = DBNull.Value;
                if (user.DeActivate)
                    _deActivate.Value = 1;
                else
                    _deActivate.Value = 0;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_firstname);
                sqlCommand.Parameters.Add(_lastname);
                sqlCommand.Parameters.Add(_username);
                sqlCommand.Parameters.Add(_password);
                sqlCommand.Parameters.Add(_email);
                sqlCommand.Parameters.Add(_emailVerified);
                sqlCommand.Parameters.Add(_emailVerificationPin);
                sqlCommand.Parameters.Add(_token);
                sqlCommand.Parameters.Add(_deActivate);
                sqlCommand.Parameters.Add(_result);

                ExecuteNonQuery(sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }
            return (int)_result.Value;
        }

        #endregion
    }
}