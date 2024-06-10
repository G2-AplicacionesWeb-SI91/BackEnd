using backend.Tracking.Domain.Repositories;

namespace backend.Tracking.Domain.Model.Queries;

public class GetRouteByIdQuery
{
    private readonly IRouteRepository _routeRepository;

    public GetRouteByIdQuery(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    public Route Execute(int routeId)
    {
        return _routeRepository.GetById(routeId);
    }
}