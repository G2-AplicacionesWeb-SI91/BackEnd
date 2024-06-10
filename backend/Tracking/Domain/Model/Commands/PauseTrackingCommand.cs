using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Domain.Model.Commands;

public class PauseTrackingCommand
{
    private readonly ITrackeable _trackeable;

    public PauseTrackingCommand(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    public void Execute()
    {
        _trackeable.PauseTracking();
    }
}