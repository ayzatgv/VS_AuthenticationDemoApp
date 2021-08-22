using AuthenticationDemoApp.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AuthenticationDemoApp.Models;

namespace AuthenticationDemoApp.DataAccess
{
    public class MenuService : MyDataAccess
    {
        #region Select

        public static List<Menu> Menus_Select(int id = 0, string controller = null, string action = null)
        {
            SqlCommand sqlCommand = GetCommand("Menus_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter _controller = new SqlParameter("@Controller", SqlDbType.NVarChar, 64);
            SqlParameter _action = new SqlParameter("@Action", SqlDbType.NVarChar, 64);

            DataTable dataTable;
            List<Menu> menus;
            try
            {
                if (id != 0)
                    _id.Value = id;
                else
                    _id.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(controller))
                    _controller.Value = controller;
                else
                    _controller.Value = DBNull.Value;
                if (!string.IsNullOrEmpty(action))
                    _action.Value = action;
                else
                    _action.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_id);
                sqlCommand.Parameters.Add(_controller);
                sqlCommand.Parameters.Add(_action);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                menus = Menu.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return menus;
        }

        #endregion
    }
}