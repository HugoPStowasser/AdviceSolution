using Application.Interfaces;

namespace HangfireJobs
{

    public class AdviceUpsertJob
    {
        private readonly IAdviceService _adviceService;

        public AdviceUpsertJob(IAdviceService adviceService)
        {
            _adviceService = adviceService;
        }

        public async Task ExecuteAsync()
        {
            var advice = await _adviceService.GetRandomAdviceAsync();
            await _adviceService.UpsertAdviceAsync(advice);
        }
    }
}
