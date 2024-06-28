using backend.Notifications.Domain.Model.Aggregates;
using backend.Notifications.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Notifications.Infrastructure.Persistence.EFC.Repositories;

public class NotificationRepository(AppDbContext context) : BaseRepository<Notification>(context), INotificationRepository
{
    public new async Task<Notification?> FindByIdAsync(int id) =>
        await Context.Set<Notification>().Include(n => n.Id)
            .Where(n => n.Id == id).FirstOrDefaultAsync();

    public async Task DeleteByIdAsync(int id)
    {
        var notification = await FindByIdAsync(id);
        if (notification != null)
        {
            Context.Set<Notification>().Remove(notification);
            await Context.SaveChangesAsync();
        }
    }
}