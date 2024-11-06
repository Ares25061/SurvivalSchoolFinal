namespace SurvivalSchool.Contracts.ForumPost
{
    public class CreateForumPostRequest
    {
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;
    }
}