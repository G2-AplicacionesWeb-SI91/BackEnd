using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Domain.Model.Commands;

public class CancelTrackingCommand
{
    private readonly ITrackeable _trackeable;

    public CancelTrackingCommand(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    public void Execute()
    {
        _trackeable.CancelTracking();
    }
}