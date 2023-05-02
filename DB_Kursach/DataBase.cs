using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB_Kursach
{
    public class DataBase
    {
         string login;
         string password;
         string connectionString;
         SqlConnection sqlConnection;

      public  DataBase(string login, string password)
        {
            this.login = login;
            this.password = password;
            connectionString = $"Data Source=MSI;Initial Catalog=Kursach_DB;User Id={login};Password={password};";
            //connectionString = $"Data Source=vsevolodsh;Initial Catalog=Kursach_DB;User Id={login};Password={password};";
            sqlConnection = new SqlConnection(connectionString);
        }

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getSqlConnection() => sqlConnection;
    }


}
