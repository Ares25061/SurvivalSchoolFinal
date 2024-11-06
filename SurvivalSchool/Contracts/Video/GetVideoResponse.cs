namespace SurvivalSchool.Contracts.Video
{
    public class GetVideoResponse
    {
        public int VideoId { get; set; }
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}