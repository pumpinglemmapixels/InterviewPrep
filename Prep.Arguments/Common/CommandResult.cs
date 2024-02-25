using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prep.Interfaces.Common
{
    public class CommandResult<ResultObject>(
        ResultObject result,
        int statusCode = 200,
        string errorMessage = ""
        )
    {

        public ResultObject Result { get; set; } = result;
        public int StatusCode { get; set; } = statusCode;
        public string ErrorMessage { get; set; } = errorMessage;
    }
    public class CommandResult(
        int statusCode = 200,
        string errorMessage = ""
        )
    {

        public int StatusCode { get; set; } = statusCode;
        public string ErrorMessage { get; set; } = errorMessage;
    }
}
