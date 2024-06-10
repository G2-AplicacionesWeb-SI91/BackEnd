using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.tracking;

public class BusRouteRepository(AppDbContext context) : BaseRepository<BusRoute>(context), IBusRouteRepository
{
    public Task<BusRoute?> FindBusRouteByDistanceAsync(Distance distance)
    {
        return Context.Set<BusRoute>().Where(b => b.TotalDistance == distance).FirstOrDefaultAsync();
    }
}