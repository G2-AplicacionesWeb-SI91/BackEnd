namespace backend.Payment.Domain.Model.ValueObjects;

public record PaymentCheck(string BusCompany, string Origin, string Destination, long MoneyAmount, string PaymentMethod);
