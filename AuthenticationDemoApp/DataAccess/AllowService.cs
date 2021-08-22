using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AuthenticationDemoApp.DataAccess
{
    public class AllowService : MyDataAccess
    {
        #region Select

        public static List<Allow> Allows_Select(int roleID = 0, int panelID = 0)
        {
            SqlCommand sqlCommand = GetCommand("Allows_Select");

            SqlParameter _roleID = new SqlParameter("@RoleID", SqlDbType.Int);
            SqlParameter _panelID = new SqlParameter("@PanelID", SqlDbType.Int);

            DataTable dataTable;
            List<Allow> allows;
            try
            {
                if (roleID != 0)
                    _roleID.Value = roleID;
                else
                    _roleID.Value = DBNull.Value;
                if (panelID != 0)
                    _panelID.Value = panelID;
                else
                    _panelID.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_roleID);
                sqlCommand.Parameters.Add(_panelID);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                allows = Allow.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return allows;
        }

        #endregion

        #region Insert

        public static int Allows_Insert(Allow allow)
        {
            SqlCommand sqlCommand = GetCommand("Allows_Insert");

            SqlParameter _roleID = new SqlParameter("@RoleID", SqlDbType.Int);
            SqlParameter _panelID = new SqlParameter("@PanelID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (allow.Role.ID != 0)
                    _roleID.Value = allow.Role.ID;
                else
                    _roleID.Value = DBNull.Value;
                if (allow.Panel.ID != 0)
                    _panelID.Value = allow.Panel.ID;
                else
                    _panelID.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_roleID);
                sqlCommand.Parameters.Add(_panelID);
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

        public static int Allows_Delete(Allow allow)
        {
            SqlCommand sqlCommand = GetCommand("Allows_Delete");

            SqlParameter _roleID = new SqlParameter("@RoleID", SqlDbType.Int);
            SqlParameter _panelID = new SqlParameter("@PanelID", SqlDbType.Int);
            SqlParameter _result = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

            try
            {
                if (allow.Role.ID != 0)
                    _roleID.Value = allow.Role.ID;
                else
                    _roleID.Value = DBNull.Value;
                if (allow.Panel.ID != 0)
                    _panelID.Value = allow.Panel.ID;
                else
                    _panelID.Value = DBNull.Value;

                _result.Direction = ParameterDirection.ReturnValue;

                sqlCommand.Parameters.Add(_roleID);
                sqlCommand.Parameters.Add(_panelID);
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