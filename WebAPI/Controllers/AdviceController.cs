using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdviceController : ControllerBase
    {
        private readonly IAdviceService _adviceService;

        public AdviceController(IAdviceService adviceService)
        {
            _adviceService = adviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Advice>>> GetAllAdvices()
        {
            var advices = await _adviceService.GetAllAdvicesAsync();
            return Ok(advices);
        }

        [HttpGet("{externalId}")]
        public async Task<ActionResult<Advice>> GetAdviceByExternalId(int externalId)
        {
            var advice = await _adviceService.GetAdviceByExternalIdAsync(externalId);
            return advice != null ? Ok(advice) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Advice>> AddAdvice([FromBody] Advice advice)
        {
            await _adviceService.UpsertAdviceAsync(advice);
            return CreatedAtAction(nameof(GetAdviceByExternalId), new { externalId = advice.ExternalId }, advice);
        }
    }
}