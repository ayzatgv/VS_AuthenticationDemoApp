using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AuthenticationDemoApp.DataAccess
{
    public class PermissionService : MyDataAccess
    {
        #region Select

        public static List<Permission> Permissions_Select(int userID = 0, int roleID = 0)
        {
            SqlCommand sqlCommand = GetCommand("Permissions_Select");

            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter _roleID = new SqlParameter("@RoleID", SqlDbType.Int);

            DataTable dataTable;
            List<Permission> permissions;
            try
            {
                if (userID != 0)
                    _userID.Value = userID;
                else
                    _userID.Value = DBNull.Value;
                if (roleID != 0)
                    _roleID.Value = roleID;
                else
                    _roleID.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_userID);
                sqlCommand.Parameters.Add(_roleID);

                dataTable= GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                permissions = Permission.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return permissions;
        }

        #endregion

        #region Insert

        public static int Permissions_Insert(Permission permission)
        {
            SqlCommand sqlCommand = GetCommand("Permissions_Insert");

            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter _roleID = new SqlParameter("@RoleID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (permission.User.ID != 0)
                    _userID.Value = permission.User.ID;
                else
                    _userID.Value = DBNull.Value;
                if (permission.Role.ID != 0)
                    _roleID.Value = permission.Role.ID;
                else
                    _roleID.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_userID);
                sqlCommand.Parameters.Add(_roleID);
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

        #region Delete

        public static int Permissions_Delete(Permission permission)
        {
            SqlCommand sqlCommand = GetCommand("Permissions_Delete");

            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter _roleID = new SqlParameter("@RoleID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (permission.User.ID != 0)
                    _userID.Value = permission.User.ID;
                else
                    _userID.Value = DBNull.Value;
                if (permission.Role.ID != 0)
                    _roleID.Value = permission.Role.ID;
                else
                    _roleID.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_userID);
                sqlCommand.Parameters.Add(_roleID);
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