using ConjugonApi.DTOs;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection.Metadata;
using ConjugonApi.Models.Domain;
using ConjugonApi.Models.Common;

namespace ConjugonApi.Services;

public class VerbsService
{
    private readonly IMongoCollection<Verb> _verbsCollection;

    public VerbsService(
        IOptions<ConjugonDatabaseSettings> conjugonDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            conjugonDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            conjugonDatabaseSettings.Value.DatabaseName);

        _verbsCollection = mongoDatabase.GetCollection<Verb>(
            conjugonDatabaseSettings.Value.ConjugonCollectionName);

        var indexKeysDefinition = Builders<Verb>.IndexKeys.Ascending(indexKey => indexKey.Infinitif);
        _verbsCollection.Indexes.CreateOne(new CreateIndexModel<Verb>(indexKeysDefinition));

        var ixList = _verbsCollection.Indexes.List().ToList<BsonDocument>();
        ixList.ForEach(ix => Console.WriteLine(ix));
    }

    public async Task<List<Verb>> GetAsync()
    {
        return await _verbsCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Verb?> GetAsync(string id) =>
        await _verbsCollection.Find(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();

    public async Task CreateAsync(Verb newVerb) => await _verbsCollection.InsertOneAsync(newVerb);

    public async Task CreateManyAsync(List<VerbDTO> newVerbs)
    {
        List<Verb> VerbToCreate = newVerbs.ConvertAll(verbDTO => Verb.CreateNew(verbDTO));

        await _verbsCollection.InsertManyAsync(VerbToCreate);
    }

    public async Task UpdateAsync(string id, Verb updatedVerb) =>
        await _verbsCollection.ReplaceOneAsync(x => x.Id == new ObjectId(id), updatedVerb);

    public async Task RemoveAsync(string id) =>
        await _verbsCollection.DeleteOneAsync(x => x.Id == new ObjectId(id));
}