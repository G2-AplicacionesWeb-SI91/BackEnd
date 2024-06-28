using backend.Notifications.Domain.Model.Aggregates;
using backend.Notifications.Domain.Model.Commands;

namespace backend.Notifications.Domain.Services;

public interface INotificationCommandService
{
    Task<Notification?> Handle(CreateNotificationCommand command);
    Task Handle(DeleteNotificationCommand command);
}