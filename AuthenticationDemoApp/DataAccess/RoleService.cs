using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AuthenticationDemoApp.DataAccess
{
    public class RoleService : MyDataAccess
    {
        #region Select

        public static List<Role> Roles_Select(int id = 0)
        {
            SqlCommand sqlCommand = GetCommand("Roles_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);

            DataTable dataTable;
            List<Role> roles;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);

                dataTable= GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                roles = Role.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return roles;
        }

        #endregion

        #region Insert

        public static int Roles_Insert(Role role)
        {
            SqlCommand sqlCommand = GetCommand("Roles_Insert");

            SqlParameter _access = new SqlParameter("@Access", SqlDbType.NVarChar, 32);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (!string.IsNullOrEmpty(role.Access))
                    _access.Value = role.Access;
                else
                    _access.Value = DBNull.Value;


                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_access);
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

        public static int Roles_Update(Role role)
        {
            SqlCommand sqlCommand = GetCommand("Roles_Update");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _access = new SqlParameter("@Access", SqlDbType.NVarChar, 32);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (role.ID != 0)
                    _id.Value = role.ID;
                else
                    _id.Value = DBNull.Value;

                if (!string.IsNullOrEmpty(role.Access))
                    _access.Value = role.Access;
                else
                    _access.Value = DBNull.Value;


                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_access);
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

        public static int Roles_Delete(int id)
        {
            SqlCommand sqlCommand = GetCommand("Roles_Delete");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_id);
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