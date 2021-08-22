using System;
using System.Collections.Generic;
using System.Data;

namespace AuthenticationDemoApp.Models
{
    public class Group
    {
        #region Variables

        private Panel _panel;
        private Menu _menu;

        #endregion

        #region Properties

        public Panel Panel
        {
            get { return _panel; }
            set { _panel = value; }
        }
        public Menu Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        #endregion

        #region Constructors

        public Group()
        {
            Panel = new Panel();
            Menu = new Menu();
        }

        #endregion

        #region Methodes

        public static List<Group> Convert(DataTable dataTable)
        {
            List<Group> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Group>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Group Convert(DataRow dataRow)
        {
            Group result = null;

            if (dataRow != null)
            {
                result = new Group();

                if (dataRow.Table.Columns.Contains("PanelID") && dataRow["PanelID"] != DBNull.Value)
                    result.Panel.ID = System.Convert.ToInt32(dataRow["PanelID"]);
                if (dataRow.Table.Columns.Contains("Description") && dataRow["Description"] != DBNull.Value)
                    result.Panel.Description = System.Convert.ToString(dataRow["Description"]);
                if (dataRow.Table.Columns.Contains("MenuID") && dataRow["MenuID"] != DBNull.Value)
                    result.Menu.ID = System.Convert.ToInt32(dataRow["MenuID"]);
                if (dataRow.Table.Columns.Contains("Controller") && dataRow["Controller"] != DBNull.Value)
                    result.Menu.Controller = System.Convert.ToString(dataRow["Controller"]);
                if (dataRow.Table.Columns.Contains("Action") && dataRow["Action"] != DBNull.Value)
                    result.Menu.Action = System.Convert.ToString(dataRow["Action"]);
            }
            return result;
        }

        #endregion
    }
}