namespace SurvivalSchool.Contracts.Test
{
    public class CreateTestRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CreatedBy { get; set; }
    }
}