using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AuthenticationDemoApp.Models
{
    public class Error
    {
        #region Variables

        private int _id;
        private string _message;

        #endregion

        #region Properties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion

        #region Methodes

        public static List<Error> Convert(DataTable dataTable)
        {
            List<Error> result = null;

            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Error>();

                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Error Convert(DataRow dataRow)
        {
            Error result = null;

            if (dataRow != null)
            {
                result = new Error();

                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Message") && dataRow["Message"] != DBNull.Value)
                    result.Message = System.Convert.ToString(dataRow["Message"]);
            }
            return result;
        }

        #endregion
    }

    public enum ErrorType
    {
        NoContent = 42023,
        InUse = 42034,
        NotFound = 42047,
        Exist = 42051
    }
}