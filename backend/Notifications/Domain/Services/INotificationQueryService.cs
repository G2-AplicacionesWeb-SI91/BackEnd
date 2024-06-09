using backend.Notifications.Domain.Model.Aggregates;
using backend.Notifications.Domain.Model.Queries;

namespace backend.Notifications.Domain.Services;

public interface INotificationQueryService
{
    Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query);
    Task<Notification?> Handle(GetNotificationByIdQuery query);
}