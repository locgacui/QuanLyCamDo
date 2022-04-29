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


    }
}
