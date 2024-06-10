using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Application.Internal.CommandServices;

public class ResumeTrackingCommandHandler
{
    private readonly ITrackeable _trackeable;

    public ResumeTrackingCommandHandler(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    public void Handle()
    {
        _trackeable.ResumeTracking();
    }
}