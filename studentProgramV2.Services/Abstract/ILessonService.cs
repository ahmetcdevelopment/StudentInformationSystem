using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentProgramV2.Entities.DTOs;
using studentProgramV2.Shared.Utilities.Results.Abstract;

namespace studentProgramV2.Services.Abstract
{
    public interface ILessonService
    {
        Task<IDataResult<LessonListDto>> GetAll();
        Task<IDataResult<LessonListDto>> GetAllByNonDeleted();
        Task<IDataResult<LessonListDto>> GetAllByNonDeletedAndActive();
        Task <IDataResult<LessonDto>>Get(int id);
        Task<IDataResult<LessonDto>> Create(LessonAddDto lessonAddDto, string createdByName);
        Task<IDataResult<LessonDto>> Update(LessonUpdateDto lessonUpdateDto, string modifiedByName);
        Task<IDataResult<LessonDto>> Delete(int id, string modifiedByName);
        Task<IResult> HardDelete(int id);



    }
}
