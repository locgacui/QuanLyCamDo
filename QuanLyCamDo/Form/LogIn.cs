using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyCamDo.DTO;
using QuanLyCamDo.DAO;
using QuanLyCamDo.ResponseAPI;
using System.Security.Cryptography;
using Newtonsoft.Json;
using QuanLyCamDo.Class;

namespace QuanLyCamDo
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bt_DangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                UltilEffect.f_Show_WaitForm();
                string UserName = tb_TaiKhoan.Text;
                string Password = Hash(tb_MatKhau.Text);
                //DataTable result = Account_DTO.Instance.sp_checkLogin_Username_Password(UserName, Password);
                //if(result.Rows[0]["Result"].ToString() == "1")
                //{
                //    MessageBox.Show(result.Rows[0]["Msg"].ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //    MessageBox.Show(result.Rows[0]["Msg"].ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("*apiMethod", "GET");
                header.Add("Content-Type", "application/json");

                List<ParameterAPI_DAO> parameters = new List<ParameterAPI_DAO>()
                {
                    new ParameterAPI_DAO ("UserName", UserName),
                    new ParameterAPI_DAO ("Password", tb_MatKhau.Text)
                };
                string jsonRespone = MasterCode.Instance.WCF_CallAPI("http://localhost:5000/api/Account/sp_checkLogin_Username_Password", parameters, header, "");
                Response response = JsonConvert.DeserializeObject<Response>(jsonRespone);
                if(response.result == 1)
                {
                    //MessageBox.Show(response.msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    alertControl1.Show(this, "Thông báo", response.msg, "", null);
                }
                else
                    MessageBox.Show(response.msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UltilEffect.f_Close_WaitForm();
            }
            catch(Exception ex)
            {
                
            }
        }

        private void bt_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
