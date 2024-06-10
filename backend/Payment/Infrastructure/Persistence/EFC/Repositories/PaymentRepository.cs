using backend.Payment.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Payment.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext context) : BaseRepository<Domain.Model.Aggregates.Payment>(context), IPaymentRepository
{
    public new async Task<Domain.Model.Aggregates.Payment?> FindByIdAsync(int id) =>
        await Context.Set<Domain.Model.Aggregates.Payment>().Include(payment => payment.PaymentCheck)
            .Where(payment => payment.Id == id).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<Domain.Model.Aggregates.Payment>> FindByBusCompanyAsync(string busCompany)
    {
        return await Context.Set<Domain.Model.Aggregates.Payment>()
            .Include(payment => payment.PaymentCheck.BusCompany)
            .Where(p => p.PaymentCheck.BusCompany == busCompany)
            .ToListAsync();
    }
}