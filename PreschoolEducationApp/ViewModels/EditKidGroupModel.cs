using PreschoolEducationApp.Enum;
using PreschoolEducationApp.Models;

namespace PreschoolEducationApp.ViewModels
{
    public class EditKidGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public string? Description { get; set; }
        public GroupCategory GroupCategory { get; set; }

    }
}
