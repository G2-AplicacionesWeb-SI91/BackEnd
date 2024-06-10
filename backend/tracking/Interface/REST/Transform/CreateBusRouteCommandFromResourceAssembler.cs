namespace backend.tracking;

public class CreateBusRouteCommandFromResourceAssembler
{
    public static CreateBusRouteCommand ToCommandFromResource(CreateBusRouteResource resource)
    {
        return new CreateBusRouteCommand(
            resource.OriginLatitude,
            resource.OriginLongitude,
            resource.DestLatitude,
            resource.DestLongitude,
            resource.Value,
            resource.Unit
        );
    }
}