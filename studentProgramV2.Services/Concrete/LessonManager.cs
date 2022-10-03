using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using studentProgramV2.Data.Abstract;
using studentProgramV2.Entities.Concrete;
using studentProgramV2.Entities.DTOs;
using studentProgramV2.Services.Abstract;
using studentProgramV2.Shared.Utilities.Results.Abstract;
using studentProgramV2.Shared.Utilities.Results.ComplexTypes;
using studentProgramV2.Shared.Utilities.Results.Concrete;

namespace studentProgramV2.Services.Concrete
{
    public class LessonManager:ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public async Task<IDataResult<LessonListDto>> GetAll()
        {
            var lesssons = await _unitOfWork.Lessons.GetAllAsync();
            if (lesssons.Count>-1)
            {
                return new DataResult<LessonListDto>(ResultStatus.Success, new LessonListDto
                {
                    Lessons = lesssons,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<LessonListDto>(ResultStatus.Error, "Seçili dersler bulunamadı.",new LessonListDto
            {
                Lessons = null,
                ResultStatus = ResultStatus.Error,
                Message = "Seçili dersler bulunamadı."
            });
        }

        public async Task<IDataResult<LessonListDto>> GetAllByNonDeleted()
        {
            var lessons = await _unitOfWork.Lessons.GetAllAsync(l => !l.IsDeleted);
            if (lessons.Count > -1)
            {
                return new DataResult<LessonListDto>(ResultStatus.Success, new LessonListDto
                {
                    Lessons = lessons,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<LessonListDto>(ResultStatus.Error, "Seçili dersler bulunamadı", new LessonListDto
            {
                Lessons = null,
                ResultStatus = ResultStatus.Error,
                Message = "Seçili dersler bulunamadı"
            });
        }

        public async Task<IDataResult<LessonListDto>> GetAllByNonDeletedAndActive()
        {
            var lessons = await _unitOfWork.Lessons.GetAllAsync(l=>!l.IsDeleted && l.IsActive);
            if (lessons.Count<-1)
            {
                return new DataResult<LessonListDto>(ResultStatus.Success, new LessonListDto
                {
                    Lessons = lessons,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<LessonListDto>(ResultStatus.Error, "Seçili dersler bulunamadı.", new LessonListDto
            {
                Lessons = null,
                ResultStatus = ResultStatus.Error,
                Message = "Seçili dersler bulunamadı."
            });
        }

        public async Task<IDataResult<LessonDto>> Get(int id)
        {
            var lesson = await _unitOfWork.Lessons.GetAsync(l => l.Id == id);
            if (lesson != null)
            {
                return new DataResult<LessonDto>(ResultStatus.Success, new LessonDto
                {
                    Lesson = lesson,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<LessonDto>(ResultStatus.Error, "Seçili ders bulunamadı", new LessonDto
            {
                Lesson = null,
                ResultStatus = ResultStatus.Error,
                Message = "Seçili ders bulunamadı."
            });
        }

        public async Task<IDataResult<LessonDto>> Create(LessonAddDto lessonAddDto, string createdByName)
        {
            var lesson= _mapper.Map<Lesson>(lessonAddDto);
            lesson.CreatedByName= createdByName;
            lesson.ModifiedByName=createdByName;
            var addedLesson = await _unitOfWork.Lessons.AddAsync(lesson);
            await _unitOfWork.SaveAsync();
            return new DataResult<LessonDto>(ResultStatus.Success, $"{lessonAddDto.Name} adlı ders başarıyla eklenmiştir.", new LessonDto
            {
                Lesson = addedLesson,
                ResultStatus = ResultStatus.Success,
                Message = $"{lessonAddDto.Name} adlı ders başarıyla eklenmiştir."
            });
        }

        public async Task<IDataResult<LessonDto>> Update(LessonUpdateDto lessonUpdateDto, string modifiedByName)
        {
            var oldLesson = await _unitOfWork.Lessons.GetAsync(l => l.Id == lessonUpdateDto.Id);
            var lesson =  _mapper.Map<LessonUpdateDto, Lesson>(lessonUpdateDto, oldLesson);
            lesson.ModifiedByName= modifiedByName;
            var updateLesson = await _unitOfWork.Lessons.UpdateAsync(lesson);
            await _unitOfWork.SaveAsync();
            return new DataResult<LessonDto>(ResultStatus.Success,
                $"{lessonUpdateDto.Name} adlı ders başarıyla güncellenmiştir.", new LessonDto
                {
                    Lesson = updateLesson,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{lessonUpdateDto.Name} adlı ders başarıyla güncellenmiştir."
                });
        }

        public async Task<IDataResult<LessonDto>> Delete(int id, string modifiedByName)
        {
            var lesson = await _unitOfWork.Lessons.GetAsync(l => l.Id == id);
            if (lesson!=null)
            {
                lesson.IsDeleted=true;
                lesson.ModifiedByName = modifiedByName;
                lesson.ModifiedDate= DateTime.Now;
                var deletedLesson = await _unitOfWork.Lessons.UpdateAsync(lesson);
                await _unitOfWork.SaveAsync();
                return new DataResult<LessonDto>(ResultStatus.Success,
                    $"{lesson.Name} adlı ders başarıyla silinmiştir.", new LessonDto
                    {
                        Lesson = deletedLesson,
                        ResultStatus = ResultStatus.Success,
                        Message = $"{lesson.Name} adlı ders başarıyla silinmiştir."
                    });
            }

            return new DataResult<LessonDto>(ResultStatus.Success, "İşleminiz gerçekleştirilemedi", new LessonDto
            {
                Lesson = null,
                ResultStatus = ResultStatus.Error,
                Message = "İşleminiz gerçekleştirilemedi"
            });
        }

        public async Task<IResult> HardDelete(int id)
        {
            var lesson = await _unitOfWork.Lessons.GetAsync(l => l.Id == id);
            if (lesson!=null)
            {
                await _unitOfWork.Lessons.DeleteAsync(lesson);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Başarıyla silindi.");
            }

            return new Result(ResultStatus.Error, "işlem gerçekleştirilemedi.");
        }
    }
}
