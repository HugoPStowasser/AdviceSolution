using System.Text.Json.Serialization;

namespace Application.DTOs;

public class AdviceSlip
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("advice")]
    public string Text { get; set; } = string.Empty;
}