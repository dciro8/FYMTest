namespace UserManager.Application.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string DocumentType { get; set; } = null!;

        public string DocumentNumber { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
        public Guid Role { get; set; }
        public bool State { get; set; }
    }
}
