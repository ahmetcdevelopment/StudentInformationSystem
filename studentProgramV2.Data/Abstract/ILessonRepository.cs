using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentProgramV2.Entities.Concrete;
using studentProgramV2.Shared.Data.Abstract;

namespace studentProgramV2.Data.Abstract
{
    public interface ILessonRepository:IEntityRepository<Lesson>
    {
    }
}
