using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Domain.Model.Commands;

public class StopTrackingCommand
{
    private readonly ITrackeable _trackeable;

    public StopTrackingCommand(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    public void Execute()
    {
        _trackeable.StopTracking();
    }
}