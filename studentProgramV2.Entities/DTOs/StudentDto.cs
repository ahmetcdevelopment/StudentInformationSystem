using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentProgramV2.Entities.Concrete;
using studentProgramV2.Shared.Utilities.Results.Abstract;

namespace studentProgramV2.Entities.DTOs
{
    public class StudentDto:DtoGetBase
    {
        public Student Student { get; set; }
    }
}
