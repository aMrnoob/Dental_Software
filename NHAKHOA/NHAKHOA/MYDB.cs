using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAKHOA
{
    internal class MYDB
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-DA8RJKG7;Initial Catalog=NHAKHOA;Integrated Security=True;");

        // get the connection
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }

        // open the connection
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }

        }

        // close the connection
        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }

        }
    }
}
