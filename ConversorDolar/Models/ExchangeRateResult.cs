namespace ConversorDolar.Models
{
    public class ExchangeRateResult
    {
        public string? Disclaimer { get; set; } = string.Empty;
        public string? License { get; set; } = string.Empty;
        public long Timestamp { get; set; }
        public string? Base { get; set; } = string.Empty;
        public System.Collections.Generic.Dictionary<string, double>? Rates { get; set; }

    }
}
