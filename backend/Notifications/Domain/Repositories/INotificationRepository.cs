using backend.Notifications.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Notifications.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<Notification> FindByIdAsync(int id);
    Task DeleteByIdAsync(int id);
}