namespace backend.Payment.Interfaces.Rest.Resources;

public record CreatePaymentResource(int Id, string BusCompany, string Origin, string Destination, long MoneyAmount, string PaymentMethod);