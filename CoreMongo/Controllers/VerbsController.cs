using ConjugonApi.Services;
using ConjugonApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ConjugonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VerbsController : ControllerBase
{
    private readonly VerbsService _verbsService;

    public VerbsController(VerbsService verbsService) =>
        _verbsService = verbsService;

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Verb>> GetById(ObjectId id)
    {
        var verb = _verbsService.Get(id);

        if (verb is null)
        {
            return NotFound();
        }

        return verb;
    }

    [HttpGet]
    public async Task<List<Verb>> Get()
    {
        return await _verbsService.GetAllAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Verb newVerb)
    {
        await _verbsService.CreateAsync(newVerb);

        return CreatedAtAction(nameof(Post), new { id = newVerb.Id }, newVerb);
    }
    
    [HttpPost("Many")]
    public async Task<IActionResult> PostMany(List<VerbDTO> newVerbs)
    {
        await _verbsService.CreateManyAsync(newVerbs);

        return CreatedAtAction(nameof(Post), new { id = 1 }, newVerbs);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(ObjectId id, Verb updatedVerb)
    {
        var verb = _verbsService.Get(id);

        if (verb is null)
        {
            return NotFound();
        }

        _verbsService.UpdateAsync(updatedVerb);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(ObjectId id)
    {
        var verb = _verbsService.Get(id);

        if (verb is null)
        {
            return NotFound();
        }

        await _verbsService.RemoveAsync(verb);

        return Ok("Removed"); //NoContent();
    }
}