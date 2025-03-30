using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AdviceService : IAdviceService
    {
        private readonly IAdviceRepository _repository;
        private readonly AdviceSlapClient _client;

        public AdviceService(IAdviceRepository repository, AdviceSlapClient client)
        {
            _repository = repository;
            _client = client;
        }

        public async Task<IEnumerable<Advice>> GetAllAdvicesAsync()
            => await _repository.GetAllAsync();

        public async Task<Advice> GetRandomAdviceAsync()
        {
            var response = await _client.GetRandomAdviceAsync();
            return new Advice
            {
                ExternalId = response.Slip.Id,
                AdviceText = response.Slip.Text
            };
        }

        public async Task UpsertAdviceAsync(Advice advice)
        {
            await _repository.UpsertAsync(advice);
        }

        public async Task<Advice?> GetAdviceByExternalIdAsync(int externalId)
        {
            return await _repository.GetByExternalIdAsync(externalId);
        }
    }
}