using ConjugonApi.Models;
using ConjugonApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ConjugonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService) =>
        _usersService = usersService;

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> GetById(ObjectId id)
    {
        var user = _usersService.Get(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await _usersService.GetAllAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _usersService.CreateAsync(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }
    
    [HttpPost("Many")]
    public async Task<IActionResult> PostMany(List<CreateUserDTO> newUsers)
    {
        await _usersService.CreateManyAsync(newUsers);

        return CreatedAtAction(nameof(Get), new { id = 1 }, newUsers);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(ObjectId id, User updatedUser)
    {
        var user = _usersService.Get(id);

        if (user is null)
        {
            return NotFound();
        }

        _usersService.UpdateAsync(updatedUser);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(ObjectId id)
    {
        var book = _usersService.Get(id);

        if (book is null)
        {
            return NotFound();
        }

        await _usersService.RemoveAsync(book);

        return Ok("Removed"); //NoContent();
    }
}