namespace SurvivalSchool.Contracts.LectureComment
{
    public class CreateLectureCommentsRequest
    {
        public int UserId { get; set; }
        public int LectureId { get; set; }
        public string CommentText { get; set; } = null!;
        public int? ParentCommentId { get; set; }
    }
}