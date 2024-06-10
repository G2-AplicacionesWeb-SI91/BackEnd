using backend.Payment.Domain.Model.Commands;
using backend.Payment.Interfaces.Rest.Resources;

namespace backend.Payment.Interfaces.Rest.Transform;

public static class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(resource.Id, resource.BusCompany, resource.Origin, resource.Destination,
            resource.MoneyAmount, resource.PaymentMethod);
    }
}