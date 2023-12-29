namespace ConjugonApi.Models
{
    public record CreateVerbDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Age { get; set; }
        public decimal Level { get; set; }
        public decimal Points { get; set; }
    }
}
