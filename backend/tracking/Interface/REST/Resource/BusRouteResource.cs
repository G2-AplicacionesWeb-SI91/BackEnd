namespace backend.tracking;

public record BusRouteResource(int Id, Coordinate Origin, Coordinate Destination, Distance TotalDistance);