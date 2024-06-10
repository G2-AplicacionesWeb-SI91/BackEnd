using backend.Tracking.Domain.Model.Aggregates;

namespace backend.Tracking.Domain.Model.ValueObjects;

public interface ITrackeable
{
    void StartTracking(int routeId);
    void PauseTracking();
    void ResumeTracking();
    void StopTracking();
    void AddLocation(double latitude, double longitude);
    BusRoute GetCurrentRoute();
    TimeSpan GetTrackDuration();
    bool IsTracking();
    string GetRouteStatus();
    void CancelTracking();
}