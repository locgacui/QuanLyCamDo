using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Net;

namespace QuanLyCamDo
{
    class MasterCode
    {
            private static MasterCode instance;

            public string cn = "Data Source=DESKTOP-9PDL730\\SQLEXPRESS;Initial Catalog=QuanLyCamDo;User ID=sa;Password=locgacui";
            internal static MasterCode Instance
            {
                get
                {
                    if (instance == null) instance = new MasterCode();
                    return instance;
                }

                set
                {
                    instance = value;
                }
            }
            public string Cn
            {
                get
                {
                    return cn;
                }

                set
                {
                    cn = value;
                }
            }

            private MasterCode() { }

            private SqlConnection con;

            public void connect()
            {
                try
                {
                    con = new SqlConnection(cn);
                    con.Open();
                }
                catch
                {
                    MessageBox.Show("Không Kết nối tới CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            public void disconect()
            {
                con.Close();
                con.Dispose();
                con = null;
            }

            public DataTable ExecuteQuery(string query, object[] parameter = null)
            {
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

            public string GetLastCode(string nameTable, string nameSelectColumn, string type)
            {
                string sql = "SELECT TOP 1 " + nameSelectColumn + " FROM " + nameTable + " WHERE " + nameSelectColumn + " LIKE N'" + type + "%' ORDER BY " + nameSelectColumn + " DESC";
                return (string)ExecuteScalar(sql);
            }

            public string GetLastCode_Document(string TypeDoc)
            {
                string sql = "SELECT TOP 1 Code FROM dbo.Document WHERE Code LIKE '" + TypeDoc + "%' ORDER BY Code DESC";
                return (string)ExecuteScalar(sql);
            }

            public string NextCode(string lastCode, string prefixCode)
            {
                if (lastCode == "")
                {
                    return prefixCode + "0001";  // fixwidth default
                }
                int nextID = int.Parse(lastCode.Remove(0, prefixCode.Length)) + 1;
                int lengthNumerID = lastCode.Length - prefixCode.Length;
                string zeroNumber = "";
                for (int i = 1; i <= lengthNumerID; i++)
                {
                    if (nextID < Math.Pow(10, i))
                    {
                        for (int j = 1; j <= lengthNumerID - i; i++)
                        {
                            zeroNumber += "0";
                        }
                        return prefixCode + zeroNumber + nextID.ToString();
                    }
                }
                return prefixCode + nextID;
            }

            public void CallAPI()
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("*apiMethod", "GET");
                header.Add("Content-Type", "application/json");
                string jsonRespone = WCF_CallAPI("http://localhost:8080/api/v1/accountById?id=1", header, "");
            }

            public string WCF_CallAPI(string domain, Dictionary<string, string> headers, string body)
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        //Header Config
                        string method = "POST";
                        wc.Encoding = Encoding.UTF8;
                        foreach (KeyValuePair<string, string> dict in headers)
                        {
                            //special key
                            if (dict.Key.Equals("*apiMethod"))
                            {
                                method = dict.Value;
                                continue;
                            }
                            //normal key
                            wc.Headers[dict.Key] = dict.Value;
                        }
                        wc.UseDefaultCredentials = true;
                        wc.Credentials = CredentialCache.DefaultCredentials;

                        // POST
                        string jsonResult = "";
                        if (method.Equals("GET"))
                        {
                            jsonResult = wc.DownloadString(domain);
                        }
                        else
                        {
                            jsonResult = wc.UploadString(domain, method, body);
                        }

                        string unwrappedJson = "";
                        if (!string.IsNullOrEmpty(jsonResult))
                        {
                            if (jsonResult[0].Equals("["))
                            {
                                unwrappedJson = JsonConvert.DeserializeObject<string>(jsonResult);
                            }
                            else
                            {
                                unwrappedJson = jsonResult;
                            }
                        }

                        return unwrappedJson;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
