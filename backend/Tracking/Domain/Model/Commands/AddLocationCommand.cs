using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Domain.Model.Commands;

public class AddLocationCommand
{
    private readonly ITrackeable _trackeable;

    public AddLocationCommand(ITrackeable trackeable)
    {
        _trackeable = trackeable;
    }

    public void Execute(double latitude, double longitude)
    {
        _trackeable.AddLocation(latitude, longitude);
    }
}