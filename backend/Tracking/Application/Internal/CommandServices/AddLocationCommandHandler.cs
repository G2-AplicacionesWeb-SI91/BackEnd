using backend.Tracking.Domain.Model.Commands;
using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Application.Internal.CommandServices;

public class AddLocationCommandHandler
{
    private readonly ITrackeable _trackeable;

    public AddLocationCommandHandler(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    // public void Handle(AddLocationCommand command)
    // {
    //     _trackeable.AddLocation(command.Latitude, command.Longitude);
    // }
}