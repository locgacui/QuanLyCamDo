using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_QuanLyCamDo
{
    public class MasterCodeAPI
    {
        private static MasterCodeAPI instance;

        internal static MasterCodeAPI Instance
        {
            get
            {
                if (instance == null) instance = new MasterCodeAPI();
                return instance;
            }

            set
            {
                instance = value;
            }
        }

        private MasterCodeAPI() { }

        private readonly IConfiguration _configuration;

        public MasterCodeAPI(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //private string cn = _configuration.GetConnectionString("QuanLyCamDo");

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            string cn = _configuration.GetConnectionString("QuanLyCamDo");
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(cn))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            string cn = _configuration.GetConnectionString("QuanLyCamDo");
            int data = 0;

            using (SqlConnection connection = new SqlConnection(cn))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            string cn = _configuration.GetConnectionString("QuanLyCamDo");
            object data = 0;

            using (SqlConnection connection = new SqlConnection(cn))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }

        public int GetId(string TableName)
        {
            int id = 1;
            string code = "select * from " + TableName;
            using (DataTable table = ExecuteQuery(code))
            {
                foreach (DataRow rw in table.Rows)
                {
                    if (id == int.Parse(rw["Id"].ToString()))
                        id++;
                }
            }
            return id;
        }
    }
}
