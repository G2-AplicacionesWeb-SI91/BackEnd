using backend.Notifications.Domain.Model.Aggregates;
using backend.Notifications.Domain.Model.Queries;
using backend.Notifications.Domain.Repositories;
using backend.Notifications.Domain.Services;

namespace backend.Notifications.Application.Internal.QueryServices;

public class NotificationQueryService(INotificationRepository notificationRepository) : INotificationQueryService
{
    public async Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query)
    {
        return await notificationRepository.ListAsync();
    }

    public async Task<Notification?> Handle(GetNotificationByIdQuery query)
    {
        return await notificationRepository.FindByIdAsync(query.Id);
    }
}