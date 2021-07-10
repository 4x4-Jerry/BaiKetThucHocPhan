using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{

    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source = DESKTOP-QVP8J3B\\SQLEXPRESS; Initial Catalog =QLDA; UID = sa; PWD = 123; ";

        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
