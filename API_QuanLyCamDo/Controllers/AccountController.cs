using API_QuanLyCamDo.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace API_QuanLyCamDo.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("GetAllAccount")]
        [HttpGet]
        public List<Account> GetAllAcount()
        {
            string query = @"
                            SELECT * FROM dbo.Account";
            DataTable table = new DataTable();
            MasterCodeAPI masterCodeAPI = new MasterCodeAPI(_configuration);
            table = masterCodeAPI.ExecuteQuery(query);

            string json = JsonConvert.SerializeObject(table);

            List<Account> accounts = new List<Account>();
            accounts = JsonConvert.DeserializeObject<List<Account>>(json);
            return accounts;
        }

        [Route("sp_checkLogin_Username_Password")]
        [HttpGet]
        public Response sp_checkLogin_Username_Password(string UserName, string Password)
        {
            Password = Hash(Password);
            string procName = "dbo.sp_checkLogin_Username_Password";

            DataTable table = new DataTable();
            MasterCodeAPI masterCodeAPI = new MasterCodeAPI(_configuration);
            List<ParameterStoredProcedure> parameters = new List<ParameterStoredProcedure>()
            { 
                new ParameterStoredProcedure("@UserName", UserName),
                new ParameterStoredProcedure("@PassWord", Password)
            };
            table = masterCodeAPI.ExecuteProc(procName, parameters);
            Response response = null;
            foreach (DataRow rw in table.Rows)
            {
                response = new Response(rw);
            }

            return response;
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
