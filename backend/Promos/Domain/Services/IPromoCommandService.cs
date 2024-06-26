using backend.Promos.Domain.Model.Commands;
using backend.Promos.Domain.Model.Entities;

namespace backend.Promos.Domain.Services;

public interface IPromoCommandService
{
    Task<Promo> Handle(CreatePromoCommand command);
}