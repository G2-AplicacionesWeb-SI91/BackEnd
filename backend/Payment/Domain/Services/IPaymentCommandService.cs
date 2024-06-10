using backend.Payment.Domain.Model.Commands;

namespace backend.Payment.Domain.Services;

public interface IPaymentCommandService
{
    public Task<Model.Aggregates.Payment?> Handle(CreatePaymentCommand command);
}