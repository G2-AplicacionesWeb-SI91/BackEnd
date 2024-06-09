using backend.Notifications.Domain.Model.Commands;
using backend.Notifications.Interfaces.Rest.Resources;

namespace backend.Notifications.Interfaces.Rest.Transform;

public static class CreateNotificationCommandFromResourceAssembler
{
    public static CreateNotificationCommand ToCommandFromResource(CreateNotificationResource resource)
    {
        return new CreateNotificationCommand(resource.Id, resource.Title, resource.Description);
    }
}