namespace ConversorDolar.Models
{
    public class Conversor
    {
        public string? FormData { get; set; }
        public List<string> Currencies { get; set; } = new List<string>();
    }
}
