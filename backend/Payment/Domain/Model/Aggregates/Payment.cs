using backend.Payment.Domain.Model.ValueObjects;

namespace backend.Payment.Domain.Model.Aggregates;

public partial class Payment
{
    public int Id { get; private set; }
    public PaymentCheck PaymentCheck { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Payment(int id, string busCompany, string origin, string destination, long moneyAmount, string paymentMethod)
    {
        Id = id;
        PaymentCheck = new PaymentCheck(busCompany, origin, destination, moneyAmount, paymentMethod);
        CreatedAt = DateTime.Now;
    }
}