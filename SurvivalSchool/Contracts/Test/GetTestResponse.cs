namespace SurvivalSchool.Contracts.Test
{
    public class GetTestResponse
    {
        public int TestId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}