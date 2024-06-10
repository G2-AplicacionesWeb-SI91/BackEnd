using backend.Notifications.Domain.Model.Aggregates;
using backend.Notifications.Domain.Model.Commands;
using backend.Notifications.Domain.Repositories;
using backend.Notifications.Domain.Services;
using backend.Shared.Domain.Repositories;

namespace backend.Notifications.Application.Internal.CommandServices;

public class NotificationCommandService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork) : INotificationCommandService
{
    public async Task<Notification?> Handle(CreateNotificationCommand command)
    {
        var notification = new Notification(command.Id, command.Title, command.Description);
        await notificationRepository.AddAsync(notification);
        await unitOfWork.CompleteAsync();
        return notification;
    }

    public Task Handle(DeleteNotificationCommand command)
    {
        return notificationRepository.DeleteByIdAsync(command.Id);
    }
}