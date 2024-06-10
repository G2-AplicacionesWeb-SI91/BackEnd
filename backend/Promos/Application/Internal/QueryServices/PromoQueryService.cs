using backend.Promos.Domain.Model.Entities;
using backend.Promos.Domain.Model.Queries;
using backend.Promos.Domain.Repositories;
using backend.Promos.Domain.Services;

namespace backend.Promos.Application.Internal.QueryServices;

public class PromoQueryService(IPromoRepository promoRepository) : IPromoQueryService
{
    public async Task<Promo> Handle(GetPromoByIdQuery query)
    {
        return await promoRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Promo>> Handle(GetPromoByTitleQuery query)
    {
        return await promoRepository.FindByTitleAsync(query.Title);
    }
}