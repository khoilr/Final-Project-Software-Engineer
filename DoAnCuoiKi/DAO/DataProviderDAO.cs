using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKi.DAO
{
    public class DataProviderDAO
    {
        private readonly String connectionString = "Data Source=se-final.database.windows.net;Initial Catalog=management;Persist Security Info=True;User ID=khoilr;Password=Culacgiontan147";
        private static DataProviderDAO instance;

        private DataProviderDAO() { }

        public static DataProviderDAO Instance
        {
            get { if (instance == null) instance = new DataProviderDAO(); return instance; }
            private set => instance = value;
        }

        public DataTable ExecuteQuery(String query, Dictionary<String, String> parameters = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameters != null)
                    foreach (KeyValuePair<String, String> parameter in parameters)
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        public bool ExecuteNoneQuery(String query, Dictionary<String, String> parameters = null)
        {
            bool data = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameters != null)
                    foreach (KeyValuePair<String, String> parameter in parameters)
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);

                int nums = cmd.ExecuteNonQuery();
                if (nums > 0) data = true;

                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(String query, Dictionary<String, String> parameters = null)
        {
            object data = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameters != null)
                    foreach (KeyValuePair<String, String> parameter in parameters)
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);

                data = cmd.ExecuteScalar();

                connection.Close();
            }
            return data;
        }
    }
}
