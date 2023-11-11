using BCrypt.Net;

namespace MelosBookStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string PasswordHash { get; set; }
        public required string PhoneNumber { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        // This property is not mapped to the database; it's used to receive plain text passwords during registration.
        public required string Password { get; set; }

        public void HashPassword()
        {
            // Hash the plain text password and set the PasswordHash property.
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}