using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Application.Internal.CommandServices;

public class StopTrackingCommandHandler
{
    private readonly ITrackeable _trackeable;

    public StopTrackingCommandHandler(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    public void Handle()
    {
        _trackeable.StopTracking();
    }
}