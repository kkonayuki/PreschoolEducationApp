using PreschoolEducationApp.Models;

namespace PreschoolEducationApp.Interfaces
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>> GetAllAsync();
        Task<Parent> GetByIdAsync(int id);
        bool Add(Parent parent);
        bool Update(Parent parent);
        bool Delete(Parent parent);
        bool Save();
    }
}
