namespace backend.tracking;

public class BusRouteResourceFromEntityAssembler
{
    public static BusRouteResource ToResourceFromEntity(BusRoute entity)
    {
        return new BusRouteResource(
            entity.Id,
            entity.Origin,
            entity.Destination,
            entity.TotalDistance
        );
    }
}