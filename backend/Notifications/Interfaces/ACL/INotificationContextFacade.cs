using backend.Notifications.Domain.Model.ValueObjects;

namespace backend.Notifications.Interfaces.ACL;

public interface INotificationContextFacade
{
    Task<int> CreateNotification(
        string title,
        string description
    );
}