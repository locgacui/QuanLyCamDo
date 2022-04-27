using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCamDo.DAO
{
    public class Account_DAO
    {
        public Account_DAO(int id, string userName, string password, int empID) {
            this.id = id;
            this.userName = userName;
            this.empID = empID;
        }

        private int id;
        private string userName;
        private string password;
        private int empID;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int EmpID
        {
            get
            {
                return empID;
            }

            set
            {
                empID = value;
            }
        }
    }
}
