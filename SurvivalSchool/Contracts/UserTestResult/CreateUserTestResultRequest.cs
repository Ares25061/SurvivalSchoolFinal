namespace SurvivalSchool.Contracts.UserTestResult
{
    public class CreateUserTestResultRequest
    {
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int Score { get; set; }
    }
}