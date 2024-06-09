using backend.Notifications.Domain.Model.ValueObjects;

namespace backend.Notifications.Domain.Model.Aggregates;

public partial class Notification
{
    public int Id { get; private set; }
    public NotificationDetails NotificationDetails { get; private set; }
    public bool IsRead { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Notification(int id, string title, string description)
    {
        Id = id;
        NotificationDetails = new NotificationDetails(title, description);
        IsRead = false;
        CreatedAt = DateTime.Now;
    }

    public void MarkAsRead()
    {
        IsRead = true;
    }
}