using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAdviceRepository
    {
        Task UpsertAsync(Advice advice);
        Task<Advice?> GetByIdAsync(int id);
        Task<IEnumerable<Advice>> GetAllAsync();
        Task<Advice?> GetByExternalIdAsync(int externalId);
    }
}
