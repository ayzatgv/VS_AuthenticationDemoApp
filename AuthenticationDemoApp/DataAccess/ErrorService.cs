using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AuthenticationDemoApp.Helpers;
using AuthenticationDemoApp.Models;

namespace AuthenticationDemoApp.DataAccess
{
    public class ErrorService : MyDataAccess
    {
        #region Select

        public static List<Error> Errors_Select(int errorCode = 0)
        {
            SqlCommand sqlCommand = GetCommand("Errors_Select");

            SqlParameter _errorCode = new SqlParameter("@ID", SqlDbType.Int);

            DataTable dataTable;
            List<Error> errors;
            try
            {
                if (errorCode != 0)
                    _errorCode.Value = errorCode;
                else
                    _errorCode.Value = DBNull.Value;

                sqlCommand.Parameters.Add(_errorCode);

                dataTable = GetDataTable(sqlCommand);
                if (dataTable.Rows.Count == 0)
                    return null;

                errors = Error.Convert(dataTable);
            }
            catch (Exception)
            {
                throw;
            }

            return errors;
        }

        #endregion
    }
}