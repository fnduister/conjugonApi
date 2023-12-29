using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ConjugonApi.Models;
using ConjugonApi.Core.Interfaces;
using ConjugonApi.Core;

namespace ConjugonApi.Services;

public class UsersService
{
    
    private DomainWork _unitOfWork;
    public UsersService(
        DomainWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _unitOfWork.Users.Get();
    }

    public User? Get(ObjectId id) => _unitOfWork.Users.GetById(id);

    public async Task CreateAsync(User newUser) => await _unitOfWork.Users.Add(newUser);

    public async Task CreateManyAsync(List<CreateUserDTO> newUsers)
    {
        List<User> UserToCreate = newUsers.ConvertAll(userDTO => User.CreateNew(userDTO));

        await _unitOfWork.Users.AddAll(UserToCreate);
    }

    public bool UpdateAsync(User updatedUser) =>
        _unitOfWork.Users.Update(updatedUser);

    public async Task RemoveAsync(User user) =>
        await _unitOfWork.Users.Delete(user);
    
    public async Task RemoveAllAsync(IEnumerable<User> users) =>
        await _unitOfWork.Users.DeleteAll(users);
}