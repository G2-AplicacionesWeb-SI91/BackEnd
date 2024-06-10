namespace backend.tracking;

public interface IBusRouteContextFacade
{
    Task<int> CreateBusRoute(
        string originLatitude,
        string originLongitude,
        string destLatitude,
        string destLongitude,
        string value,
        string unit
    );

    Task<int> FetchBusRouteIdByDistance(string value, string unit);
}