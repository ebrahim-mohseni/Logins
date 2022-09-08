namespace Logins.Model.DTO
{
    public class CreateUserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public int UserTypeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int PositionId { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string Address { get; set; } = string.Empty;

    }
}
