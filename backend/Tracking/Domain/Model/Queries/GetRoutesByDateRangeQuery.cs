using backend.Tracking.Domain.Model.ValueObjects;
using backend.Tracking.Domain.Repositories;

namespace backend.Tracking.Domain.Model.Queries;

public class GetRoutesByDateRangeQuery
{
    // private readonly IRouteRepository _routeRepository;
    //
    // public GetRoutesByDateRangeQuery(IRouteRepository routeRepository)
    // {
    //     _routeRepository = routeRepository;
    // }
    //
    // public IEnumerable<Route> Execute(TimeRange dateRange)
    // {
    //     // Lógica para obtener rutas dentro del rango de fechas
    //     return _routeRepository.GetAll().Where(route =>
    //         route.Locations.Any(location => dateRange.Contains(location.Timestamp)));
    // }
}