namespace backend.Tracking.Domain.Model.Entities;

public class BusRoute
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Location> Locations { get; private set; }

    public BusRoute(int id, string name)
    {
        Id = id;
        Name = name;
        Locations = new List<Location>();
    }

    public void AddLocation(double latitude, double longitude)
    {
        Locations.Add(new Location(latitude, longitude));
    }
}