namespace SurvivalSchool.Contracts.Notification
{
    public class GetNotificationsResponse
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string NotificationType { get; set; } = null!;
        public string NotificationText { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}