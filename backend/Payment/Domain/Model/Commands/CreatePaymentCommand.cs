namespace backend.Payment.Domain.Model.Commands;

public record CreatePaymentCommand(int Id, string BusCompany, string Origin, string Destination, long MoneyAmount, string PaymentMethod);