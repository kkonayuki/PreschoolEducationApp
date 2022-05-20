using PreschoolEducationApp.Data;
using PreschoolEducationApp.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreschoolEducationApp.Models
{
    public class KidGroup
    {
        private readonly PreschoolDbContext _context;

        public KidGroup(PreschoolDbContext context)
        {
            _context = context;
        }
        public KidGroup()
        {

        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public GroupCategory GroupCategory { get; set; }

        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<Kid>? Kids { get; set; }

        public int CountOfKids() => _context.Kids.Where(p=>p.KidGroupId == Id).Count();

        




    }
}
