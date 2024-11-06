namespace SurvivalSchool.Contracts.User
{
    public class GetUserResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int RoleId { get; set; }
    }
}