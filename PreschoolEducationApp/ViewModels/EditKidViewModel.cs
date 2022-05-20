using PreschoolEducationApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreschoolEducationApp.ViewModels
{
    public class EditKidViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(1, 6)]
        public int Age { get; set; }
        [ForeignKey("KidGroup")]
        public int KidGroupId { get; set; }
        public KidGroup? KidGroups { get; set; }
        public ICollection<Parent>? Parents { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
