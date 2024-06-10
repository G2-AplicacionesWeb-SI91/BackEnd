using backend.Tracking.Domain.Model.Queries;
using backend.Tracking.Domain.Repositories;

namespace backend.Tracking.Application.Internal.QueryService;

public class GetRouteByIdQueryHandler
{
    private readonly IRouteRepository _routeRepository;

    public GetRouteByIdQueryHandler(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    // public Route Handle(GetRouteByIdQuery query)
    // {
    //     return _routeRepository.GetById(query.RouteId);
    // }
}