using studentProgramV2.Entities.DTOs;
using studentProgramV2.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentProgramV2.Services.Abstract
{
    public interface IStudentService
    {
        Task<IDataResult<StudentDto>> Get(int studentId);
        Task<IDataResult<StudentListDto>> GetAll();
        Task<IDataResult<StudentListDto>> GetAllByNonDeleted();
        Task<IDataResult<StudentListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<StudentDto>> Create(StudentAddDto studentAddDto, string createdByName);
        Task<IDataResult<StudentDto>> Update(StudentUpdateDto studentUpdateDto, string modifiedByName);
        Task<IDataResult<StudentDto>> Delete(int studentId, string modifiedByName);
        Task<IResult> HardDelete(int studentId);

    }
}
