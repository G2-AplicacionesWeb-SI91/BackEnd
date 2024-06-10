using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Domain.Model.Commands;

public class StartTrackingCommand
{
    private readonly ITrackeable _trackeable;
    private readonly int _routeId;

    public StartTrackingCommand(ITrackeable trackeable, int routeId)
    {
        _trackeable = trackeable;
        _routeId = routeId;
    }

    public void Execute(int routeId)
    {
        _trackeable.StartTracking(routeId);
    }
}