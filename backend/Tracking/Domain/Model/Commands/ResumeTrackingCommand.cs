using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Domain.Model.Commands;

public class ResumeTrackingCommand
{
    private readonly ITrackeable _trackeable;

    public ResumeTrackingCommand(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    public void Execute()
    {
        _trackeable.ResumeTracking();
    }
}