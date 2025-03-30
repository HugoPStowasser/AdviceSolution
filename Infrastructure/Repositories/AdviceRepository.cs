using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AdviceRepository : IAdviceRepository
    {
        private readonly AppDbContext _context;

        public AdviceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task UpsertAsync(Advice advice)
        {
            var existing = await _context.Advices
                .FirstOrDefaultAsync(a => a.ExternalId == advice.ExternalId);

            if (existing == null)
            {
                _context.Advices.Add(advice);
            }
            else
            {
                existing.AdviceText = advice.AdviceText;
                existing.CreatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Advice?> GetByIdAsync(int id)
            => await _context.Advices.FindAsync(id);

        public async Task<Advice?> GetByExternalIdAsync(int externalId)
            => await _context.Advices.FirstOrDefaultAsync(a => a.ExternalId == externalId);

        public async Task<IEnumerable<Advice>> GetAllAsync()
            => await _context.Advices.ToListAsync();
    }
}
