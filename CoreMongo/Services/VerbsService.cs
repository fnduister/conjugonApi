using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ConjugonApi.Models;
using ConjugonApi.Core.Interfaces;
using ConjugonApi.Core;

namespace ConjugonApi.Services;

public class VerbsService
{

    private DomainWork _unitOfWork;
    public VerbsService(
        DomainWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Verb>> GetAllAsync()
    {
        return await _unitOfWork.Verbs.Get();
    }

    public Verb? Get(ObjectId id) => _unitOfWork.Verbs.GetById(id);

    public async Task CreateAsync(Verb newVerb) => await _unitOfWork.Verbs.Add(newVerb);

    public async Task CreateManyAsync(List<VerbDTO> newVerbs)
    {
        List<Verb> VerbToCreate = newVerbs.ConvertAll(VerbDTO => Verb.CreateNew(VerbDTO));

        await _unitOfWork.Verbs.AddAll(VerbToCreate);
    }

    public bool UpdateAsync(Verb updatedVerb) =>
        _unitOfWork.Verbs.Update(updatedVerb);

    public async Task RemoveAsync(Verb Verb) =>
        await _unitOfWork.Verbs.Delete(Verb);

    public async Task RemoveAllAsync(IEnumerable<Verb> Verbs) =>
        await _unitOfWork.Verbs.DeleteAll(Verbs);
}