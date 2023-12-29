using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConjugonApi.Models
{
    public record UserDTO: EntityBase
    {
        public required string Username { get; set; }
        public int Age { get; set; }
        public decimal Level { get; set; }
        public decimal Points { get; set; }
        public List<Guid>? FavoriteVerbs { get; set; }
        public List<Guid>? FavoriteTenses { get; set; }
        public List<Guid>? Friends { get; set; }
    }
}

