namespace SurvivalSchool.Contracts.Notification
{
    public class CreateNotificationsRequest
    {
        public int UserId { get; set; }
        public string NotificationType { get; set; } = null!;
        public string NotificationText { get; set; } = null!;
    }
}