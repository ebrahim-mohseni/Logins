namespace Logins.Model.DTO
{
    public class UpdateUserDto
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int UserTypeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int PositionId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; } = string.Empty;

        public List<LookupDto> PositionList { get; set; }
        public List<LookupDto> UserTypeList { get; set; }
    }
}
