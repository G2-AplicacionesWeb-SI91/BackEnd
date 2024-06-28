using backend.Notifications.Domain.Model.Commands;
using backend.Notifications.Domain.Model.ValueObjects;
using backend.Notifications.Domain.Services;

namespace backend.Notifications.Interfaces.ACL.Services;

public class NotificationContextFacade(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService) : INotificationContextFacade
{
    public async Task<int> CreateNotification(string title, string description)
    {
        var createNotificationCommand = new CreateNotificationCommand(title, description);
        var notification = await notificationCommandService.Handle(createNotificationCommand);
        return notification?.Id ?? 0;
    }
}