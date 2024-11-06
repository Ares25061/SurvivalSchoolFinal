namespace SurvivalSchool.Contracts.Lecture
{
    public class CreateLectureRequest
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
    }
}