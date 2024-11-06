namespace SurvivalSchool.Contracts.ForumThread
{
    public class GetForumThreadResponse
    {
        public int ThreadId { get; set; }
        public string Title { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}