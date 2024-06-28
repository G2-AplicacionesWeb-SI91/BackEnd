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
        var notification = new Notification(command.Title, command.Description);
        try
        {
            await notificationRepository.AddAsync(notification);
            await unitOfWork.CompleteAsync();
            return notification;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error ocurred while creating the notification: " + e.Message);
            return null;
        }
    }

    public Task Handle(DeleteNotificationCommand command)
    {
        return notificationRepository.DeleteByIdAsync(command.Id);
    }
}