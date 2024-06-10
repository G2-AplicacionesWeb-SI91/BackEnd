using backend.Payment.Domain.Model.Queries;
using backend.Payment.Domain.Services;
using backend.Payment.Interfaces.Rest.Resources;
using backend.Payment.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend.Payment.Interfaces.Rest;

[ApiController]
[Route("api/v1/payments")]
public class PaymentsController(IPaymentCommandService paymentCommandService, IPaymentQueryService paymentQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource createPaymentResource)
    {
        var createPaymentCommand = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(createPaymentResource);
        var payment = await paymentCommandService.Handle(createPaymentCommand);
        if (payment is null) return BadRequest();
        var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return CreatedAtAction(nameof(GetPaymentById), new { id = resource.Id }, resource);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentById([FromRoute] int id)
    {
        var payment = await paymentQueryService.Handle(new GetPaymentByIdQuery(id));
        if (payment is null) return BadRequest();
        var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPayments()
    {
        var getAllPaymentsQuery = new GetAllPaymentsQuery();
        var payments = await paymentQueryService.Handle(getAllPaymentsQuery);
        var resources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPaymentsByBusCompany(string busCompany)
    {
        var getAllPaymentsByBusCompanyQuery = new GetAllPaymentsByBusCompany(busCompany);
        var payments = await paymentQueryService.Handle(getAllPaymentsByBusCompanyQuery);
        var resources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}