namespace ConjugonApi.Models
{
    public record User: IEntity
    {

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Age { get; set; }
        public decimal Level { get; set; }
        public decimal Points { get; set; }
        public List<Guid>? FavoriteVerbs { get; set; }
        public List<Guid>? FavoriteTenses { get; set; }
        public List<Guid>? Friends { get; set; }

        public static User CreateNew(CreateUserDTO newUser)
        {
            return new User
            {
                Password = newUser.Password,
                Username = newUser.Username,
                Age = newUser.Age,
                Level = newUser.Level,
                Points = newUser.Points,
            };
        }
    }
}

