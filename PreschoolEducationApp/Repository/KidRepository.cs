using Microsoft.EntityFrameworkCore;
using PreschoolEducationApp.Data;
using PreschoolEducationApp.Interfaces;
using PreschoolEducationApp.Models;

namespace PreschoolEducationApp.Repository
{
    public class KidRepository : IKidRepository
    {
        private readonly PreschoolDbContext _context;

        public KidRepository(PreschoolDbContext context)
        {
            _context = context;
        }
        public bool Add(Kid kid)
        {
            _context.Add(kid);
            return Save();
        }

        public bool Delete(Kid kid)
        {
            _context.Remove(kid);
            return Save();
        }

        public async Task<IEnumerable<Kid>> GetAllAsync()
        {
            return await _context.Kids.Include(p => p.KidGroups).ToListAsync();
        }

        public async Task<Kid> GetByIdAsync(int id)
        {
            return await _context.Kids.Include(p=>p.KidGroups).FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Kid kid)
        {
            _context.Update(kid);
            return Save();
        }
    }
}
