using backend.Notifications.Domain.Model.Queries;
using backend.Notifications.Domain.Services;
using backend.Notifications.Interfaces.Rest.Resources;
using backend.Notifications.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend.Notifications.Interfaces.Rest;

[ApiController]
[Route("api/v1/notifications")]
public class NotificationsController(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationResource createNotificationResource)
    {
        var createNotificationCommand = CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(createNotificationResource);
        var notification = await notificationCommandService.Handle(createNotificationCommand);
        if (notification is null) return BadRequest();
        var resource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return CreatedAtAction(nameof(GetNotificationById), new { id = resource.Id }, resource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetNotificationById([FromRoute] int id)
    {
        var notification = await notificationQueryService.Handle(new GetNotificationByIdQuery(id));
        if (notification is null) return BadRequest();
        var resource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotifications()
    {
        var getAllNotificationsQuery = new GetAllNotificationsQuery();
        var notifications = await notificationQueryService.Handle(getAllNotificationsQuery);
        var resources = notifications.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}