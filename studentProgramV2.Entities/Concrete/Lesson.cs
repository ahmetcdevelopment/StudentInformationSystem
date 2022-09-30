using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentProgramV2.Entities.Abstract;
using studentProgramV2.Shared.Entities.Abstract;

namespace studentProgramV2.Entities.Concrete
{
    public class Lesson:EntityBase,IEntity
    {
        public string Name { get; set; }
        public int Credit { get; set; }

    }
}
