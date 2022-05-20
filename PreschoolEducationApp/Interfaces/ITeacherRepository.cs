using PreschoolEducationApp.Models;

namespace PreschoolEducationApp.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        bool Add(Teacher teacher);
        bool Update(Teacher teacher);
        bool Delete(Teacher teacher);
        bool Save();
    }
}
