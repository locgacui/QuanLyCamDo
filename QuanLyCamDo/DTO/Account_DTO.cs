using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCamDo;

namespace QuanLyCamDo.DTO
{
    public class Account_DTO
    {
        private static Account_DTO instance;

        public static Account_DTO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Account_DTO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public Account_DTO() { }

        public DataTable sp_checkLogin_Username_Password(string UserName, string Password)
        {
            string sql = @"EXEC dbo.sp_checkLogin_Username_Password @UserName = '"+UserName+@"', -- varchar(50)
                                         @PassWord = '"+Password+"'  -- varchar(250)";

            DataTable result = MasterCode.Instance.ExecuteQuery(sql);
            return result;
        }
    }
}
