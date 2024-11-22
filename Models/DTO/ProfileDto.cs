using System.Text.Json.Serialization;

namespace Register.Models.DTO
{
    public class ProfileDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


       
    }
}
