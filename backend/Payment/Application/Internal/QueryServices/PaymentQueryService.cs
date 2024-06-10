using backend.Payment.Domain.Model.Queries;
using backend.Payment.Domain.Repositories;
using backend.Payment.Domain.Services;

namespace backend.Payment.Application.Internal.QueryServices;

public class PaymentQueryService(IPaymentRepository paymentRepository) : IPaymentQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await paymentRepository.ListAsync();
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Payment>> Handle(GetAllPaymentsByBusCompany query)
    {
        return await paymentRepository.FindByBusCompanyAsync(query.BusCompany);
    }

    public async Task<Domain.Model.Aggregates.Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await paymentRepository.FindByIdAsync(query.Id);
    }
}