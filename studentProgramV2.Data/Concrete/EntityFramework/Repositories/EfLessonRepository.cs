using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using studentProgramV2.Data.Abstract;
using studentProgramV2.Entities.Concrete;
using studentProgramV2.Shared.Data.Concrete;

namespace studentProgramV2.Data.Concrete.EntityFramework.Repositories
{
    public class EfLessonRepository:EntityRepositoryBase<Lesson>,ILessonRepository
    {
        public EfLessonRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
