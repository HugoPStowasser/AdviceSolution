using System.Text.Json.Serialization;

namespace Application.DTOs;

public class AdviceSlipResponse
{
    [JsonPropertyName("slip")]
    public AdviceSlip Slip { get; set; } = null!;
}