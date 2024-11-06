namespace SurvivalSchool.Contracts.ForumThread
{
    public class CreateForumThreadRequest
    {
        public string Title { get; set; } = null!;
        public int CreatedBy { get; set; }
    }
}