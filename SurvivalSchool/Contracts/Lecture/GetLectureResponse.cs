namespace SurvivalSchool.Contracts.Lecture
{
    public class GetLectureResponse
    {
        public int LectureId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? PhotoUrl { get; set; }
        public bool IsApproved { get; set; }
    }
}