using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection.Metadata;
using ConjugonApi.Models.Domain;
using ConjugonApi.Models.Common;
using CoreMongo.Models.DTOs;

namespace ConjugonApi.Services;

public class UsersService
{
    private readonly IMongoCollection<User> _usersCollection;

    public UsersService(
        IOptions<ConjugonDatabaseSettings> conjugonDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            conjugonDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            conjugonDatabaseSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(
            conjugonDatabaseSettings.Value.ConjugonCollectionName);

        var indexKeysDefinition = Builders<User>.IndexKeys.Ascending(indexKey => indexKey.Username);
        _usersCollection.Indexes.CreateOne(new CreateIndexModel<User>(indexKeysDefinition));

        var ixList = _usersCollection.Indexes.List().ToList<BsonDocument>();
        ixList.ForEach(ix => Console.WriteLine(ix));
    }

    public async Task<List<User>> GetAsync()
    {
        return await _usersCollection.Find(_ => true).ToListAsync();
    }

    public async Task<User?> GetAsync(string id) =>
        await _usersCollection.Find(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) => await _usersCollection.InsertOneAsync(newUser);

    public async Task CreateManyAsync(List<CreateUserDTO> newUsers)
    {
        List<User> UserToCreate = newUsers.ConvertAll(userDTO => User.CreateNew(userDTO));

        await _usersCollection.InsertManyAsync(UserToCreate);
    }

    public async Task UpdateAsync(string id, User updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.Id == new ObjectId(id), updatedUser);

    public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == new ObjectId(id));
}