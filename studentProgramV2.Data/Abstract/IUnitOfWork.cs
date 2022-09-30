using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentProgramV2.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ILessonRepository Lessons { get; }//unitOfWork.Lessons.AddAsync()
        IStudentRepository Students { get; }
        Task<int> SaveAsync();
    }
}
