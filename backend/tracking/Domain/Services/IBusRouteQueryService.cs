namespace backend.tracking;

public interface IBusRouteQueryService
{
    Task<IEnumerable<BusRoute>> Handle(GetAllBusRoutesQuery query);
    Task<BusRoute?> Handle(GetBusRouteByDistanceQuery query);
    Task<BusRoute?> Handle(GetBusRouteByIdQuery query);
}