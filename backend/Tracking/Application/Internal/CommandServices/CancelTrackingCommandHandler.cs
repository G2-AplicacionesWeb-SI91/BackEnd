using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Application.Internal.CommandServices;

public class CancelTrackingCommandHandler
{
    private readonly ITrackeable _trackeable;

    public CancelTrackingCommandHandler(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    public void Handle()
    {
        _trackeable.CancelTracking();
    }
}