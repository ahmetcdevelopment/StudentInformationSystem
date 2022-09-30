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
    public class StudentManager:IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public async Task<IDataResult<StudentDto>> Get(int studentId)
        {
            var student = await _unitOfWork.Students.GetAsync(s => s.Id == studentId);
            if (student != null)
            {
                return new DataResult<StudentDto>(ResultStatus.Success, new StudentDto
                {
                    Student = student,
                    ResultStatus = ResultStatus.Success,
                });
            }

            return new DataResult<StudentDto>(ResultStatus.Success, "Böyle bir öğrenci bulunamadı", new StudentDto
            {
                Student = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir öğrenci bulunamadı"
            });
        }

        public async Task<IDataResult<StudentListDto>> GetAll()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            if (students.Count>-1)
            {
                return new DataResult<StudentListDto>(ResultStatus.Success, new StudentListDto
                {
                    Students = students,
                    ResultStatus = ResultStatus.Success,
                });
            }

            return new DataResult<StudentListDto>(ResultStatus.Success, "Öğrenciler bulunamadı", new StudentListDto
            {
                Students = null,
                ResultStatus = ResultStatus.Error,
                Message = "Öğrenciler bulunamadı"
            });
        }

        public async Task<IDataResult<StudentListDto>> GetAllByNonDeleted()
        {
            var students = await _unitOfWork.Students.GetAllAsync(s=>!s.IsDeleted);
            if (students.Count > -1)
            {
                return new DataResult<StudentListDto>(ResultStatus.Success, new StudentListDto
                {
                    Students = students,
                    ResultStatus = ResultStatus.Success,
                });
            }

            return new DataResult<StudentListDto>(ResultStatus.Success, "Öğrenciler bulunamadı", new StudentListDto
            {
                Students = null,
                ResultStatus = ResultStatus.Error,
                Message = "Öğrenciler bulunamadı"
            });
        }

        public async Task<IDataResult<StudentListDto>> GetAllByNonDeletedAndActive()
        {
            var students = await _unitOfWork.Students.GetAllAsync(s=>!s.IsDeleted&&s.IsActive);
            if (students.Count > -1)
            {
                return new DataResult<StudentListDto>(ResultStatus.Success, new StudentListDto
                {
                    Students = students,
                    ResultStatus = ResultStatus.Success,
                });
            }

            return new DataResult<StudentListDto>(ResultStatus.Success, "Öğrenciler bulunamadı", new StudentListDto
            {
                Students = null,
                ResultStatus = ResultStatus.Error,
                Message = "Öğrenciler bulunamadı"
            });
        }

        public async Task<IDataResult<StudentDto>> Create(StudentAddDto studentAddDto, string createdByName)
        {
            var student = _mapper.Map<Student>(studentAddDto);
            student.CreatedByName=createdByName;
            student.ModifiedByName=createdByName;
            var addedStudent = await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveAsync();
            return new DataResult<StudentDto>(ResultStatus.Success,
                $"{studentAddDto.Name} adlı öğrenci başarıyla eklenmiştir.", new StudentDto
                {
                    Student = addedStudent,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{studentAddDto.Name} adlı öğrenci başarıyla eklenmiştir."
                });
        }

        public async Task<IDataResult<StudentDto>> Update(StudentUpdateDto studentUpdateDto, string modifiedByName)
        {
            var currentStudent = await _unitOfWork.Students.GetAsync(s => s.Id == studentUpdateDto.Id);
            var student = _mapper.Map<StudentUpdateDto, Student>(studentUpdateDto, currentStudent);
            student.ModifiedByName=modifiedByName;
            var updatedStudent = await _unitOfWork.Students.UpdateAsync(student);
            await _unitOfWork.SaveAsync();
            return new DataResult<StudentDto>(ResultStatus.Success,
                $"{studentUpdateDto.Name} adlı öğrenci başarıyla güncellenmiştir.", new StudentDto
                {
                    Student = updatedStudent,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{studentUpdateDto.Name} adlı öğrenci başarıyla güncellenmiştir."
                });
        }

        public async Task<IDataResult<StudentDto>> Delete(int studentId, string modifiedByName)
        {
            var student = await _unitOfWork.Students.GetAsync(s => s.Id == studentId);
            if (student!=null)
            {
                student.IsDeleted=true;
                student.ModifiedByName=modifiedByName;
                student.ModifiedDate=DateTime.Now;
                var deletedStudent = await _unitOfWork.Students.UpdateAsync(student);
                await _unitOfWork.SaveAsync();
                return new DataResult<StudentDto>(ResultStatus.Success,
                    $"{deletedStudent.Name} adlı öğrenci başarıyla silinmiştir.", new StudentDto
                    {
                        Student = deletedStudent,
                        ResultStatus = ResultStatus.Success,
                        Message = $"{deletedStudent.Name} adlı öğrenci başarıyla silinmiştir."
                    });
            }
            return new DataResult<StudentDto>(ResultStatus.Error, "İşleminiz gerçekleştirilemedi.", new StudentDto
                {
                    Student = null,
                    ResultStatus = ResultStatus.Error,
                    Message="İşleminiz gerçekleştirilemedi."
                });
        }

        public async Task<IResult> HardDelete(int studentId)
        {
            var student = await _unitOfWork.Students.GetAsync(s => s.Id == studentId);
            if (student != null)
            {
                await _unitOfWork.Students.DeleteAsync(student);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Tamamen silindi!");
            }
            return new Result(ResultStatus.Error, "Öğrenci bulunamadı");
        }
    }
}
