namespace SurvivalSchool.Contracts.UserTestResult
{
    public class GetUserTestResultResponse
    {
        public int ResultId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int Score { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}