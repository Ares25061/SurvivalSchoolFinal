namespace SurvivalSchool.Contracts.VideoComment
{
    public class CreateVideoCommentsRequest
    {
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public string CommentText { get; set; } = null!;
        public int? ParentCommentId { get; set; }
    }
}