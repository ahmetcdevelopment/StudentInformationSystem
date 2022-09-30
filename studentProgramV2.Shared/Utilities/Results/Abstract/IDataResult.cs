using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentProgramV2.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult
    {
        public T Data { get; }// new DataResult<IList<Student>>(ResultStatus.Success,categoryListDto)
    }
}
