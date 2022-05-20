using PreschoolEducationApp.Enum;

namespace PreschoolEducationApp.ViewModels
{
    public class CreateKidGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string? Description { get; set; }
        public GroupCategory GroupCategory { get; set; }
    }
}
