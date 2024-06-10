using backend.Tracking.Domain.Model.Queries;
using backend.Tracking.Domain.Repositories;

namespace backend.Tracking.Application.Internal.QueryService;

public class GetAllRoutesQueryHandler
{
    private readonly IRouteRepository _routeRepository;

    public GetAllRoutesQueryHandler(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    public IEnumerable<Route> Handle(GetAllRoutesQuery query)
    {
        return _routeRepository.GetAll();
    }
}