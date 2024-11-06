namespace SurvivalSchool.Contracts.Video
{
    public class CreateVideoRequest
    {
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
    }
}