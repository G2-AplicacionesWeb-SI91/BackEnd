using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Application.Internal.CommandServices;

public class PauseTrackingCommandHandler
{
    private readonly ITrackeable _trackeable;

    public PauseTrackingCommandHandler(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    public void Handle()
    {
        _trackeable.PauseTracking();
    }
}