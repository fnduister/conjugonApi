using ConjugonApi.Models;
using ConjugonApi.Services;
using ConjugonApi.DTOs;
using ConjugonApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConjugonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VerbsController : ControllerBase
{
    private readonly VerbsService _usersService;

    public VerbsController(VerbsService verbsService) =>
        _usersService = verbsService;



    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Verb>> GetById(string id)
    {
        
        var verb = await _usersService.GetAsync(id);

        if (verb is null)
        {
            return NotFound();
        }

        return verb;
    }

    [HttpGet]
    public async Task<List<Verb>> Get()
    {
        return await _usersService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Verb newVerb)
    {
        await _usersService.CreateAsync(newVerb);

        return CreatedAtAction(nameof(Get), new { id = newVerb.Id }, newVerb);
    }
    
    [HttpPost("Many")]
    public async Task<IActionResult> PostMany(List<VerbDTO> newVerbs)
    {
        await _usersService.CreateManyAsync(newVerbs);

        return CreatedAtAction(nameof(Get), new { id = 1 }, newVerbs);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Verb updatedVerb)
    {
        var verb = await _usersService.GetAsync(id);

        if (verb is null)
        {
            return NotFound();
        }

        await _usersService.UpdateAsync(id, updatedVerb);

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