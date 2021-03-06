using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API_QuanLyCamDo.Modules
{
    public class Response
    {
        public Response(DataRow rw)
        {
            this.result = int.Parse(rw["Result"].ToString());
            this.msg = rw["Msg"].ToString().Trim();
        }

        public Response() { }

        public int result { get; set; }
        public string msg { get; set; }
    }
}
