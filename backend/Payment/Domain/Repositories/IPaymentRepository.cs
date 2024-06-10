using backend.Shared.Domain.Repositories;

namespace backend.Payment.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Model.Aggregates.Payment>
{
    Task<IEnumerable<Model.Aggregates.Payment>> FindByBusCompanyAsync(string busCompany);
}