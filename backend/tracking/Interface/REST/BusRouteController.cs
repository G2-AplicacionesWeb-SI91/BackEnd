using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.tracking.Interface.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BusRouteController(
    IBusRouteCommandService busRouteCommandService,
    IBusRouteQueryService busRouteQueryService
    ) : ControllerBase
{
    // [HttpGet("{busRouteId:int}")]
    // [SwaggerOperation(
    //     Summary = "Get a bus route by id",
    //     Description = "Gets a bus route for a given identifier",
    //     OperationId = "GetBusRouteById")]
    // [SwaggerResponse(200, "The category was found", typeof(BusRouteResource))]
    // public async Task<IActionResult> GetBusRouteById(int busRouteId)
    // {
    //     var getBusRouteByIdQuery = new GetBusRouteByIdQuery(busRouteId);
    //     var busRoute = await busRouteQueryService.Handle(getBusRouteByIdQuery);
    //     var resource = BusRouteResourceFromEntityAssembler.ToResourceFromEntity(busRoute);
    //     return Ok(resource);
    // }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all bus routes",
        Description = "Gets all bus routes",
        OperationId = "GetAllBusRoutes")]
    [SwaggerResponse(200, "The categories were found", typeof(IEnumerable<BusRouteResource>))]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllBusRoutes = new GetAllBusRoutesQuery();
        var busRoutes = await busRouteQueryService.Handle(getAllBusRoutes);
        var resources = busRoutes.Select(BusRouteResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}