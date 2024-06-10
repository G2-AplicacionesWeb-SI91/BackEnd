namespace backend.tracking;

public record CreateBusRouteCommand(
    string originLatitude, 
    string originLongitude,
    string destLatitude, 
    string destLongitude,
    string value, 
    string unit
    );