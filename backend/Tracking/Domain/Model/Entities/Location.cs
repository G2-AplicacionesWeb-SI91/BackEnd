using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Domain.Model.Entities;

public class Location
{
    public GeoCoordinate Coordinate { get; private set; }
    public DateTime Timestamp { get; private set; }

    public Location(double latitude, double longitude)
    {
        Coordinate = new GeoCoordinate(latitude, longitude);
        Timestamp = DateTime.Now;
    }
}