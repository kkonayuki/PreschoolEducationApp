using PreschoolEducationApp.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PreschoolEducationApp.Models
{
    public class Teacher
    {
        private readonly PreschoolDbContext _context;

        public Teacher(PreschoolDbContext context)
        {
            _context = context;
        }
        public Teacher()
        {

        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [ForeignKey("KidGroup")]
        public int? KidGroupId { get; set; }
        [JsonIgnore]
        public KidGroup? KidGroup { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        public string GetName() => $"{FirstName} {LastName}";

    }
}
