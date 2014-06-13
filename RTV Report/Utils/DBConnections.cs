using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace RTV_Report.Utils
{
    public class DBConnections
    {
        private const string CONN_STR = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";

        public static OleDbConnection NewConnection()
        {
            string connectStr = CONN_STR + Application.StartupPath + "\\database\\RTV.accdb";
            return new OleDbConnection(connectStr);
        }
    }
}
