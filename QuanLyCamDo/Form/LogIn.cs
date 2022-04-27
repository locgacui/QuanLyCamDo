using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyCamDo.DTO;
using System.Security.Cryptography;

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
                string UserName = tb_TaiKhoan.Text;
                string Password = Hash(tb_MatKhau.Text);

                DataTable result = Account_DTO.Instance.sp_checkLogin_Username_Password(UserName, Password);
                if(result.Rows[0]["Result"].ToString() == "1")
                {
                    MessageBox.Show(result.Rows[0]["Msg"].ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(result.Rows[0]["Msg"].ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
