namespace backend.Notifications.Domain.Model.Commands;

public record CreateNotificationCommand(int Id, string Title, string Description);
