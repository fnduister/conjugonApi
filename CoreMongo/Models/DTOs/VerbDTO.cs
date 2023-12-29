namespace ConjugonApi.Models
{
    public class VerbDTO
    {
        public required string Infinitif { get; set; }
        public string? ParticipePasse { get; set; }
        public string? ParticipePresent { get; set; }
        public string? Auxiliaire { get; set; }
        public string? FormePronominale { get; set; }
        public List<string>? Present { get; set; }
        public List<string>? Imparfait { get; set; }
        public List<string>? PasseSimple { get; set; }
        public List<string>? FuturSimple { get; set; }
        public List<string>? PlusQueParfait { get; set; }
        public List<string>? FuturAnterieur { get; set; }
        public List<string>? PasseCompose { get; set; }
        public List<string>? PasseAnterieur { get; set; }
        public List<string>? SubjonctifPresent { get; set; }
        public List<string>? SubjonctifImparfait { get; set; }
        public List<string>? SubjonctifPasse { get; set; }
        public List<string>? SubjonctifPlusQueParfait { get; set; }
        public List<string>? ConditionnelPasse { get; set; }
        public List<string>? ConditionnelPresent { get; set; }
        public List<string>? ConditionnelPasseII { get; set; }
        public List<string>? Imperatif { get; set; }
        public List<string>? ImperatifPasse { get; set; }

    }
}
