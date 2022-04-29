using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QuanLyCamDo.Modules
{
    public class ParameterStoredProcedure
    {
        public ParameterStoredProcedure(string parameterName, string parameterValue)
        {
            this.parameterName = parameterName;
            this.parameterValue = parameterValue;
        }

        public string parameterName { get; set; }
        public string parameterValue { get; set; }
    }
}
