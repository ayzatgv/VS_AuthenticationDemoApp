using AuthenticationDemoApp.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AuthenticationDemoApp.Models;

namespace AuthenticationDemoApp.DataAccess
{
    public class PanelService : MyDataAccess
    {
        #region Select

        public static List<Panel> Panels_Select(int id = 0)
        {
            SqlCommand sqlCommand = GetCommand("Panels_Select");

            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);

            DataTable dataTable;
            List<Panel> panels;
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

                panels = Panel.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return panels;
        }

        #endregion
    }
}