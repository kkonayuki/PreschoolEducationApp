using PreschoolEducationApp.Models;
using System.Collections.Generic;

namespace PreschoolEducationApp.Interfaces
{
    public interface IKidGroupRepository
    {
        Task<IEnumerable<KidGroup>> GetAllAsync();
        Task<KidGroup> GetByIdAsync(int id);
        Task<KidGroup> GetByIdAsyncNoTracking(int id);
        bool Add(KidGroup group);
        bool Update(KidGroup group);
        bool Delete(KidGroup group);
        bool Save();

    }
}
