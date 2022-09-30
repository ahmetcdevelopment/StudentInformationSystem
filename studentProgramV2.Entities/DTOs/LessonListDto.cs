﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentProgramV2.Entities.Concrete;
using studentProgramV2.Shared.Utilities.Results.Abstract;

namespace studentProgramV2.Entities.DTOs
{
    public class LessonListDto:DtoGetBase
    {
        public IList<Lesson> Lessons { get; set; }
    }
}
