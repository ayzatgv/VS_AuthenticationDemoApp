using System;
using System.Collections.Generic;
using System.Data;

namespace AuthenticationDemoApp.Models
{
    public class Role
    {
        #region Variables

        private int _id;
        private string _access;

        #endregion

        #region Properties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Access
        {
            get { return _access; }
            set { _access = value; }
        }

        #endregion

        #region Constructors

        #endregion

        #region Methodes

        public static List<Role> Convert(DataTable dataTable)
        {
            List<Role> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Role>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Role Convert(DataRow dataRow)
        {
            Role result = null;

            if (dataRow != null)
            {
                result = new Role();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Access") && dataRow["Access"] != DBNull.Value)
                    result.Access = System.Convert.ToString(dataRow["Access"]);
            }
            return result;
        }

        #endregion
    }
}
