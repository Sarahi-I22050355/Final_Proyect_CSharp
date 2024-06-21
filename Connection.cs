using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Proyect_CSharp
{
    internal class Connection
    {
        private static SqlConnectio connection;

        private static void Connect()
        {
            string connectionString = @"server=HP-SARAHI\\SARAHIDB; database=SongsDB; integrated security=true";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        private static void Disconnect()
        {
            connection.Close();
        }
        public static void ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            Connect();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                command.ExecuteNonQuery();
            }
            Disconnect();
        }
        public static DataTable GetDataTable(string query, params SqlParameter[] parameters)
        {
            Connect();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                DataTable dataTable = new DataTable();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }

                Disconnect();
                return dataTable;
            }
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            Connect();
            object result = null;
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                result = command.ExecuteScalar();
            }
            Disconnect();
            return result;
        }

    }

}
