using Microsoft.EntityFrameworkCore;
using PreschoolEducationApp.Data;
using PreschoolEducationApp.Interfaces;
using PreschoolEducationApp.Models;

namespace PreschoolEducationApp.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly PreschoolDbContext _context;

        public TeacherRepository(PreschoolDbContext context)
        {
            _context = context;
        }
        public bool Add(Teacher teacher)
        {
            _context.Add(teacher);
            return Save();
        }

        public bool Delete(Teacher teacher)
        {
            _context.Remove(teacher);
            return Save();
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(p=>p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Teacher teacher)
        {
            _context.Update(teacher);
            return Save();
        }
    }
}
