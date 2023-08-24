using ConjugonApi.Models;
using ConjugonApi.Services;
using ConjugonApi.DTOs;
using ConjugonApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConjugonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService) =>
        _usersService = usersService;



    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> GetById(string id)
    {
        
        var user = await _usersService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await _usersService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _usersService.CreateAsync(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }
    
    [HttpPost("Many")]
    public async Task<IActionResult> PostMany(List<UserDTO> newUsers)
    {
        await _usersService.CreateManyAsync(newUsers);

        return CreatedAtAction(nameof(Get), new { id = 1 }, newUsers);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, User updatedUser)
    {
        var user = await _usersService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        await _usersService.UpdateAsync(id, updatedUser);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _usersService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _usersService.RemoveAsync(id);

        return Ok("Removed"); //NoContent();
    }
}