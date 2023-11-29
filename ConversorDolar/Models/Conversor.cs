namespace ConversorDolar.Models
{
    public class Conversor
    {
        public string? FormValor { get; set; } = string.Empty;
        public string? CurrencyDe { get; set; } = string.Empty;
        public string? CurrencyPara { get; set; } = string.Empty;
        public List<string> Currencies { get; set; } = new List<string>();
    }
}
