using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCamDo.DAO
{
    public class ParameterAPI_DAO
    {
        public ParameterAPI_DAO(string parameterName, string parameterValue)
        {
            this.parameterName = parameterName;
            this.parameterValue = parameterValue;
        }

        public string parameterName { get; set; }
        public string parameterValue { get; set; }
    }
}
