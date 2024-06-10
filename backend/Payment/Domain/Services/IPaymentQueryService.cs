using backend.Payment.Domain.Model.Queries;

namespace backend.Payment.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Model.Aggregates.Payment>> Handle(GetAllPaymentsQuery query);
    Task<IEnumerable<Model.Aggregates.Payment>> Handle(GetAllPaymentsByBusCompany query);
    Task<Model.Aggregates.Payment?> Handle(GetPaymentByIdQuery query);
}