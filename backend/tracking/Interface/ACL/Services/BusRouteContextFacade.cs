namespace backend.tracking;

public class BusRouteContextFacade(
    IBusRouteCommandService busRouteCommandService,
    IBusRouteQueryService busRouteQueryService
    ) : IBusRouteContextFacade
{
    public async Task<int> CreateBusRoute(string originLatitude, string originLongitude, string destLatitude, string destLongitude,
        string value, string unit)
    {
        var createBusRouteCommand = new CreateBusRouteCommand(originLatitude, originLongitude, destLatitude, destLongitude, value, unit);
        var busRoute = await busRouteCommandService.Handle(createBusRouteCommand);
        return busRoute?.Id ?? 0;
    }

    public async Task<int> FetchBusRouteIdByDistance(string value, string unit)
    {
        var getBusRouteByDistanceQuery = new GetBusRouteByDistanceQuery(new Distance(value, unit));
        var busRoute = await busRouteQueryService.Handle(getBusRouteByDistanceQuery);
        return busRoute?.Id ?? 0;
    }
}