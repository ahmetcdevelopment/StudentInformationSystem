using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentProgramV2.Data.Abstract;
using studentProgramV2.Data.Concrete.EntityFramework.Contexts;
using studentProgramV2.Data.Concrete.EntityFramework.Repositories;

namespace studentProgramV2.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly studentProgramV2Context _context;
        private EfStudentRepository _studentRepository;
        private EfLessonRepository _lessonRepository;

        public UnitOfWork(studentProgramV2Context context)
        {
            _context = context;
        }

        public ILessonRepository Lessons => _lessonRepository ?? new EfLessonRepository(_context);

        public IStudentRepository Students => _studentRepository ?? new EfStudentRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
