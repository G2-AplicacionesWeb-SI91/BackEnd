using backend.Notifications.Domain.Model.ValueObjects;

namespace backend.Notifications.Domain.Model.Aggregates;

public partial class Notification
{
    public int Id { get; private set; }
    public NotificationDetails NotificationDetails { get; private set; }
    public Notification(string title, string description)
    {
        NotificationDetails = new NotificationDetails(title, description);
    }
}