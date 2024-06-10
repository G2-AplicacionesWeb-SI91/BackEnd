namespace backend.tracking;

public partial class BusRoute
{
    public int Id { get; private set; }
    public Coordinate Origin { get; private set; }
    public Coordinate Destination { get; private set; }
    // public List<Stop> Stops { get; private set; }
    public Distance TotalDistance { get; private set; }

    public BusRoute()
    {
        Origin = new Coordinate();
        Destination = new Coordinate();
        // Stops = new List<Stop>();
        TotalDistance = new Distance();
    }
    
    // Falta agregar stops y timewindow
    public BusRoute(
        string originLatitude, 
        string originLongitude,
        string destLatitude, 
        string destLongitude,
        string value, 
        string unit
        )
    {
        Origin = new Coordinate(originLatitude, originLongitude);
        Destination = new Coordinate(destLatitude, destLongitude);
        // Stops = new List<Stop>(location, address, timeWindow);
        TotalDistance = new Distance(value, unit);
    }


    public BusRoute(CreateBusRouteCommand command)
    {
        Origin = new Coordinate(command.originLatitude, command.originLongitude);
        Destination = new Coordinate(command.destLatitude, command.destLongitude);
        TotalDistance = new Distance(command.value, command.unit);
    }
}