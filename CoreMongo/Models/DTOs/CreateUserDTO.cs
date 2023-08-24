namespace CoreMongo.Models.DTOs
{
    public record CreateUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public decimal Level { get; set; }
        public decimal Points { get; set; }
    }
}
