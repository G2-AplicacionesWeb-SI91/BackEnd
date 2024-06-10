namespace backend.Tracking.Domain.Model.ValueObjects;

public enum BusRouteStatus
{
    NotStarted,
    Tracking,
    Paused,
    Completed,
    Cancelled
}