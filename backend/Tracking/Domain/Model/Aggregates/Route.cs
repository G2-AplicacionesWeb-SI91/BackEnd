namespace backend.Tracking.Domain.Model.Aggregates;

public class Route
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Location> Locations { get; private set; }

    public Route(int id, string name)
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