using backend.Tracking.Domain.Repositories;

namespace backend.Tracking.Domain.Model.Queries;

public class GetAllRoutesQuery
{
    private readonly IRouteRepository _routeRepository;

    public GetAllRoutesQuery(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    public IEnumerable<Route> Execute()
    {
        return _routeRepository.GetAll();
    }
}