using AuthenticationDemoApp.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AuthenticationDemoApp.Models;

namespace AuthenticationDemoApp.DataAccess
{
    public class GroupService : MyDataAccess
    {
        #region Select

        public static List<Group> Groups_Select(int panelID = 0, int menuID = 0)
        {
            SqlCommand sqlCommand = GetCommand("Groups_Select");

            SqlParameter _panelID = new SqlParameter("@PanelID", SqlDbType.Int);
            SqlParameter _menuID = new SqlParameter("@MenuID", SqlDbType.Int);

            DataTable dataTable;
            List<Group> groups;
            try
            {
                if (panelID != 0)
                    _panelID.Value = panelID;
                else
                    _panelID.Value = DBNull.Value;
                if (menuID != 0)
                    _menuID.Value = menuID;
                else
                    _menuID.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_panelID);
                sqlCommand.Parameters.Add(_menuID);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                groups = Group.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return groups;
        }

        #endregion
    }
}