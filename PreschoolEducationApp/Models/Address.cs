using System.ComponentModel.DataAnnotations;

namespace PreschoolEducationApp.Models
{
    public class Address
    {
        public Address()
        {

        }
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
