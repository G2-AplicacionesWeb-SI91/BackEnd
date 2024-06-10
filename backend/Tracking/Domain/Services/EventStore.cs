namespace backend.Tracking.Domain.Services;

public class EventStore
{
    private readonly Dictionary<int, List<object>> _events = new Dictionary<int, List<object>>();

    public void AddEvent(int routeId, object @event)
    {
        if (!_events.ContainsKey(routeId))
        {
            _events[routeId] = new List<object>();
        }
        _events[routeId].Add(@event);
    }

    public IEnumerable<object> GetEvents(int routeId)
    {
        if (_events.ContainsKey(routeId))
        {
            return _events[routeId];
        }
        return Array.Empty<object>();
    }
}