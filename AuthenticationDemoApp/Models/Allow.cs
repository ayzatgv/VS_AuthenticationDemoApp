using System;
using System.Collections.Generic;
using System.Data;

namespace AuthenticationDemoApp.Models
{
    public class Allow
    {
        #region Variables

        private Role _role;
        private Panel _panel;

        #endregion

        #region Properties

        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public Panel Panel
        {
            get { return _panel; }
            set { _panel = value; }
        }

        #endregion

        #region Constructors

        public Allow()
        {
            Role = new Role();
            Panel = new Panel();
        }

        #endregion

        #region Methodes

        public static List<Allow> Convert(DataTable dataTable)
        {
            List<Allow> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Allow>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Allow Convert(DataRow dataRow)
        {
            Allow result = null;

            if (dataRow != null)
            {
                result = new Allow();

                if (dataRow.Table.Columns.Contains("RoleID") && dataRow["RoleID"] != DBNull.Value)
                    result.Role.ID = System.Convert.ToInt32(dataRow["RoleID"]);
                if (dataRow.Table.Columns.Contains("Access") && dataRow["Access"] != DBNull.Value)
                    result.Role.Access = System.Convert.ToString(dataRow["Access"]);
                if (dataRow.Table.Columns.Contains("PanelID") && dataRow["PanelID"] != DBNull.Value)
                    result.Panel.ID = System.Convert.ToInt32(dataRow["PanelID"]);
                if (dataRow.Table.Columns.Contains("Name") && dataRow["Name"] != DBNull.Value)
                    result.Panel.Name = System.Convert.ToString(dataRow["Name"]);
                if (dataRow.Table.Columns.Contains("Description") && dataRow["Description"] != DBNull.Value)
                    result.Panel.Description = System.Convert.ToString(dataRow["Description"]);
            }
            return result;
        }

        #endregion
    }
}