using backend.Payment.Domain.Model.ValueObjects;

namespace backend.Payment.Interfaces.Rest.Resources;

public record PaymentResource(int Id, PaymentCheck PaymentCheck);