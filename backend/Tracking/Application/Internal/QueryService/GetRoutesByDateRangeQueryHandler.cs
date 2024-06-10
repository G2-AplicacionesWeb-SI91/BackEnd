using backend.Tracking.Domain.Model.Queries;
using backend.Tracking.Domain.Repositories;

namespace backend.Tracking.Application.Internal.QueryService;

public class GetRoutesByDateRangeQueryHandler
{
    private readonly IRouteRepository _routeRepository;

    public GetRoutesByDateRangeQueryHandler(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    // public IEnumerable<Route> Handle(GetRoutesByDateRangeQuery query)
    // {
    //     return _routeRepository.GetByDateRange(query.DateRange);
    // }
}