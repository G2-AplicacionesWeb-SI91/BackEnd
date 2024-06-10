namespace backend.Tracking.Domain.Repositories;

public interface IRouteRepository
{
    void Add(Route route);
    void Update(Route route);
    void Delete(Route route);
    Route GetById(int id);
    IEnumerable<Route> GetAll();
}