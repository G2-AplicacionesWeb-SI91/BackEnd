

using backend.Tracking.Domain.Model.ValueObjects;

namespace backend.Tracking.Domain.Model.Aggregates;

public partial class BusRoute : ITrackeable
    {
        public int Id { get; private set; }
        public List<Location> Locations { get; private set; }
        public BusRouteStatus Status { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public TimeSpan TrackDuration => (EndTime ?? DateTime.Now) - StartTime;

        public BusRoute(int id)
        {
            Id = id;
            Locations = new List<Location>();
            Status = BusRouteStatus.NotStarted;
        }

        public void StartTracking(int routeId)
        {
            if (routeId != Id)
                throw new ArgumentException("Route ID mismatch.");

            Status = BusRouteStatus.Tracking;
            StartTime = DateTime.Now;
        }

        public void PauseTracking()
        {
            if (Status != BusRouteStatus.Tracking)
                throw new InvalidOperationException("Route is not currently tracking.");

            Status = BusRouteStatus.Paused;
        }

        public void ResumeTracking()
        {
            if (Status != BusRouteStatus.Paused)
                throw new InvalidOperationException("Route is not currently paused.");

            Status = BusRouteStatus.Tracking;
        }

        public void StopTracking()
        {
            if (Status != BusRouteStatus.Tracking)
                throw new InvalidOperationException("Route is not currently tracking.");

            Status = BusRouteStatus.Completed;
            EndTime = DateTime.Now;
        }

        public void AddLocation(double latitude, double longitude)
        {
            if (Status != BusRouteStatus.Tracking)
                throw new InvalidOperationException("Route is not currently tracking.");

            Locations.Add(new Location(latitude, longitude));
        }

        public BusRoute GetCurrentRoute()
        {
            return this;
        }

        public TimeSpan GetTrackDuration()
        {
            return TrackDuration;
        }

        public bool IsTracking()
        {
            return Status == BusRouteStatus.Tracking;
        }

        public string GetRouteStatus()
        {
            return Status.ToString();
        }

        public void CancelTracking()
        {
            if (Status != BusRouteStatus.Tracking && Status != BusRouteStatus.Paused)
                throw new InvalidOperationException("Route cannot be cancelled in its current state.");

            Status = BusRouteStatus.Cancelled;
        }
    }