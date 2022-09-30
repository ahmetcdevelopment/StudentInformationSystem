using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentProgramV2.Shared.Utilities.Results.Abstract;
using studentProgramV2.Shared.Utilities.Results.ComplexTypes;

namespace studentProgramV2.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus=resultStatus;
        }

        public Result(ResultStatus resultStatus,string massage)
        {
            ResultStatus = resultStatus;
            Message=massage;
        }
        public Result(ResultStatus resultStatus, string massage,Exception exception)
        {
            ResultStatus = resultStatus;
            Message = massage;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }

        public Exception Exception { get; }
    }
}
