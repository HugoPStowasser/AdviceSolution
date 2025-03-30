using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAdviceService
    {
        Task<Advice> GetRandomAdviceAsync();
        Task UpsertAdviceAsync(Advice advice);
        Task<IEnumerable<Advice>> GetAllAdvicesAsync();
        Task<Advice?> GetAdviceByExternalIdAsync(int externalId);
    }
}
