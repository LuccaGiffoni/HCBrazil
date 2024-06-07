using System.Text.Json.Serialization;
using HCBrazil.Core.Enums;

namespace HCBrazil.Core.Models
{
    public class Address
    {
        [JsonPropertyName("cep")] public string Cep { get; set; } = null!;
        [JsonPropertyName("logradouro")] public string Logradouro { get; set; } = null!;
        [JsonPropertyName("complemento")] public string? Complemento { get; set; }
        [JsonPropertyName("bairro")] public string Bairro { get; set; } = null!;
        [JsonPropertyName("localidade")] public string Localidade { get; set; } = null!;
        [JsonPropertyName("uf")] public string Uf { get; set; } = null!;
        [JsonPropertyName("ibge")] public string? Ibge { get; set; }
        [JsonPropertyName("gia")] public string? Gia { get; set; }
        [JsonPropertyName("ddd")] public string? Ddd { get; set; }
        [JsonPropertyName("siafi")] public string? Siafi { get; set; }

        public string GetStateFullName()
        {
            return Enum.TryParse<EBrazilianStates>(Uf, out var state)
                ? state.GetDisplayName() : "Unknown";
        }
    }
}