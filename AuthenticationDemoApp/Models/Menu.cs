using System;
using System.Collections.Generic;
using System.Data;

namespace AuthenticationDemoApp.Models
{
    public class Menu
    {
        #region Variables

        private int _id;
        private string _action;
        private string _controller;

        #endregion

        #region Properties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        public string Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        #endregion

        #region Constructors


        #endregion

        #region Methodes

        public static List<Menu> Convert(DataTable dataTable)
        {
            List<Menu> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Menu>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Menu Convert(DataRow dataRow)
        {
            Menu result = null;

            if (dataRow != null)
            {
                result = new Menu();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Controller") && dataRow["Controller"] != DBNull.Value)
                    result.Controller = System.Convert.ToString(dataRow["Controller"]);
                if (dataRow.Table.Columns.Contains("Action") && dataRow["Action"] != DBNull.Value)
                    result.Action = System.Convert.ToString(dataRow["Action"]);
            }
            return result;
        }

        #endregion
    }
}
