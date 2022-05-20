using Microsoft.EntityFrameworkCore;
using PreschoolEducationApp.Data;
using PreschoolEducationApp.Interfaces;
using PreschoolEducationApp.Models;

namespace PreschoolEducationApp.Repository
{
    public class ParentRepository : IParentRepository
    {
        private readonly PreschoolDbContext _context;

        public ParentRepository(PreschoolDbContext context)
        {
            _context = context;
        }
        public bool Add(Parent parent)
        {
            _context.Add(parent);
            return Save();
        }

        public bool Delete(Parent parent)
        {
            _context.Remove(parent);
            return Save();
        }

        public async Task<IEnumerable<Parent>> GetAllAsync()
        {
            return await _context.Parents.ToListAsync();
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            return await _context.Parents.FirstOrDefaultAsync(p=>p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Parent parent)
        {
            _context.Update(parent);
            return Save();
        }
    }
}
