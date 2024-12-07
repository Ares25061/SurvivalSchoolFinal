namespace SurvivalSchool.Contracts.LectureComment
{
    public class GetLectureCommentsResponse
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int LectureId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? ParentCommentId { get; set; }
    }
}