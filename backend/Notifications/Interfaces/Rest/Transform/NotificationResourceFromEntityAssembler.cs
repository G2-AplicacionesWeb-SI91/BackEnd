using backend.Notifications.Domain.Model.Aggregates;
using backend.Notifications.Interfaces.Rest.Resources;

namespace backend.Notifications.Interfaces.Rest.Transform;

public static class NotificationResourceFromEntityAssembler
{
    public static NotificationResource ToResourceFromEntity(Notification entity)
    {
        return new NotificationResource(
            entity.Id,
            entity.NotificationDetails.Title,
            entity.NotificationDetails.Description);
    }
}