using PreschoolEducationApp.Models;

namespace PreschoolEducationApp.Interfaces
{
    public interface IKidRepository
    {
        Task<IEnumerable<Kid>> GetAllAsync();
        Task<Kid> GetByIdAsync(int id);
        bool Add(Kid kid);
        bool Update(Kid kid);
        bool Delete(Kid kid);
        bool Save();
    }
}
