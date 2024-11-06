namespace SurvivalSchool.Contracts.ForumPost
{
    public class GetForumPostResponse
    {
        public int PostId { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}