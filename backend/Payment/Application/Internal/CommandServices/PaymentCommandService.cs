using backend.Payment.Domain.Model.Commands;
using backend.Payment.Domain.Repositories;
using backend.Payment.Domain.Services;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend.Payment.Application.Internal.CommandServices;

public class PaymentCommandService(IPaymentRepository paymentRepository, UnitOfWork unitOfWork) : IPaymentCommandService
{
    public async Task<Domain.Model.Aggregates.Payment?> Handle(CreatePaymentCommand command)
    {
        var payment = new Domain.Model.Aggregates.Payment(command.Id, command.BusCompany, command.Origin, command.Destination, command.MoneyAmount, command.PaymentMethod);
        await paymentRepository.AddSync(payment);
        await unitOfWork.CompleteAsync();
        return payment;
    }
}