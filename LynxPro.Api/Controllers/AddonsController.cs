using LynxPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LynxPro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddonsController(LynxContext context) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<Addon>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var addons = await context.Set<Addon>().ToListAsync(cancellationToken);
        return Ok(addons);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType<Addon>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetValue(int id, CancellationToken cancellationToken)
    {
        var addons = await context.Set<Addon>().SingleOrDefaultAsync(a => a.AddonId == id, cancellationToken);

        return Ok(addons);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(AddonCommand command, CancellationToken cancellationToken)
    {
        Addon addon = new()
        {
            Id = command.Id,
            Name = command.Name,
            Type = command.Type, 
            Json = "{\"scopes\":[\"SolverConfiguration\",\"DistanceMatrix\"]}"
        };

        context.Set<Addon>().Add(addon);
        await context.SaveChangesAsync(cancellationToken);

        return Created();
    }
}