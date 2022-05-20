using Microsoft.EntityFrameworkCore;
using PreschoolEducationApp.Data;
using PreschoolEducationApp.Interfaces;
using PreschoolEducationApp.Models;

namespace PreschoolEducationApp.Repository
{
    public class KidGroupRepository : IKidGroupRepository
    {
        private readonly PreschoolDbContext _context;

        public KidGroupRepository(PreschoolDbContext context)
        {
            _context = context;
        }
        public bool Add(KidGroup group)
        {
            _context.Add(group);
            return Save();
        }

        public bool Delete(KidGroup group)
        {
            _context.Remove(group);
            return Save();
        }

        public async Task<IEnumerable<KidGroup>> GetAllAsync()
        {
            return await _context.KidGroups.ToListAsync();
        }

        public async Task<KidGroup> GetByIdAsync(int id)
        {
            return await _context.KidGroups.Include(p=>p.Teachers).Include(p=>p.Kids).FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<KidGroup> GetByIdAsyncNoTracking(int id)
        {
            return await _context.KidGroups.Include(p => p.Teachers).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(KidGroup group)
        {
            _context.Update(group);
            return Save();
        }
    }
}