using backend.Notifications.Domain.Model.ValueObjects;

namespace backend.Notifications.Interfaces.Rest.Resources;

public record NotificationResource(int Id, NotificationDetails NotificationDetails);