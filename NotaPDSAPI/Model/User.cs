using System.ComponentModel.DataAnnotations;

namespace NotaPDSAPI.Model
{
    public class User
	{
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? MobileNumber { get; set; }
        public string? ProjectLeiterNumber { get; set; }
        public bool ProjectLeiter { get; set; }
    }
}