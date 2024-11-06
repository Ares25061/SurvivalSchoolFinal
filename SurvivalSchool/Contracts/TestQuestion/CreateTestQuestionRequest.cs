namespace SurvivalSchool.Contracts.TestQuestion
{
    public class CreateTestQuestionRequest
    {
        public int TestId { get; set; }
        public string QuestionText { get; set; } = null!;
        public string CorrectAnswer { get; set; } = null!;
    }
}