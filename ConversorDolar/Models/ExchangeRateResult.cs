namespace ConversorDolar.Models
{
    public class ExchangeRateResult
    {
        public string? Disclaimer { get; set; }
        public string? License { get; set; }
        public long Timestamp { get; set; }
        public string? Base { get; set; }
        public System.Collections.Generic.Dictionary<string, double>? Rates { get; set; }

    }
}
