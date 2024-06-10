namespace backend.tracking;

public record CreateBusRouteResource(
    string OriginLatitude, 
    string OriginLongitude,
    string DestLatitude, 
    string DestLongitude,
    string Value, 
    string Unit
    );