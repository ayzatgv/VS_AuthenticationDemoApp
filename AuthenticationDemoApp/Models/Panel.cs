using System;
using System.Collections.Generic;
using System.Data;

namespace AuthenticationDemoApp.Models
{
    public class Panel
    {
        #region Variables

        private int _id;
        private string _name;
        private string _description;

        #endregion

        #region Properties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion

        #region Constructors

        #endregion

        #region Methodes

        public static List<Panel> Convert(DataTable dataTable)
        {
            List<Panel> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Panel>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Panel Convert(DataRow dataRow)
        {
            Panel result = null;

            if (dataRow != null)
            {
                result = new Panel();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Name") && dataRow["Name"] != DBNull.Value)
                    result.Name = System.Convert.ToString(dataRow["Name"]);
                if (dataRow.Table.Columns.Contains("Description") && dataRow["Description"] != DBNull.Value)
                    result.Description = System.Convert.ToString(dataRow["Description"]);
            }
            return result;
        }

        #endregion
    }
}