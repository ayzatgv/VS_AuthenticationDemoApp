using System;
using System.Collections.Generic;
using System.Data;

namespace AuthenticationDemoApp.Models
{
    public class Permission
    {
        #region Variables

        private User _user;
        private Role _role;

        #endregion

        #region Properties

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }

        #endregion

        #region Constructors

        public Permission()
        {
            User = new User();
            Role = new Role();
        }

        #endregion

        #region Methodes

        public static List<Permission> Convert(DataTable dataTable)
        {
            List<Permission> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Permission>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Permission Convert(DataRow dataRow)
        {
            Permission result = null;

            if (dataRow != null)
            {
                result = new Permission();

                if (dataRow.Table.Columns.Contains("UserID") && dataRow["UserID"] != DBNull.Value)
                    result.User.ID = System.Convert.ToInt32(dataRow["UserID"]);
                if (dataRow.Table.Columns.Contains("RoleID") && dataRow["RoleID"] != DBNull.Value)
                    result.Role.ID = System.Convert.ToInt32(dataRow["RoleID"]);
                if (dataRow.Table.Columns.Contains("Username") && dataRow["Username"] != DBNull.Value)
                    result.User.Username = System.Convert.ToString(dataRow["Username"]);
                if (dataRow.Table.Columns.Contains("Access") && dataRow["Access"] != DBNull.Value)
                    result.Role.Access = System.Convert.ToString(dataRow["Access"]);
            }
            return result;
        }

        #endregion
    }
}