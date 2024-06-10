using backend.Tracking.Domain.Repositories;

namespace backend.Tracking.Infrastructure.Persistence.EFC.Repositories;

public class EFRouteRepository : IRouteRepository
{
    private readonly TrackingDbContext _dbContext;

    public EFRouteRepository(TrackingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Route route)
    {
        _dbContext.Routes.Add(route);
        _dbContext.SaveChanges();
    }

    public void Update(Route route)
    {
        _dbContext.Routes.Update(route);
        _dbContext.SaveChanges();
    }

    public void Delete(Route route)
    {
        _dbContext.Routes.Remove(route);
        _dbContext.SaveChanges();
    }

    public Route GetById(int id)
    {
        return _dbContext.Routes.FirstOrDefault(route => route.Id == id);
    }

    public IEnumerable<Route> GetAll()
    {
        return _dbContext.Routes.ToList();
    }
}