namespace MelosBookStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string PhoneNumber { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        public void HashPassword()
        {
            // Hash the plain text password and set the PasswordHash property.
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(PasswordHash);
        }

        public bool VerifyPassword(string password)
        {
            // Verify the provided plain text password against the hashed password.
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}
