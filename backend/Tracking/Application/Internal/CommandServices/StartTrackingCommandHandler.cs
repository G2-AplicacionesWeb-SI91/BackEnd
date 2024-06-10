using backend.Tracking.Domain.Model.Commands;
using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Application.Internal.CommandServices;

public class StartTrackingCommandHandler
{
    private readonly ITrackeable _trackeable;

    public StartTrackingCommandHandler(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    // public void Handle(StartTrackingCommand command)
    // {
    //     _trackeable.StartTracking(command.routeId);
    // }
}