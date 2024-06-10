using backend.Payment.Interfaces.Rest.Resources;

namespace backend.Payment.Interfaces.Rest.Transform;

public static class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Domain.Model.Aggregates.Payment entity)
    {
        return new PaymentResource(
            entity.Id, 
            entity.PaymentCheck);
    }
}