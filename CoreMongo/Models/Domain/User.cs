
using ConjugonApi.Models.Common;
using CoreMongo.Models.DTOs;

namespace ConjugonApi.Models.Domain
{
    public record User: EntityBase
    {

        public string Username { get; set; }
        public string Password { get; set; }
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

