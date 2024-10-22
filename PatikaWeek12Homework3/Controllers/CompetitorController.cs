using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatikaWeek12Homework3.Entities;

[ApiController]
[Route("api/[controller]")]
public class CompetitorController : ControllerBase
{
    private readonly SurvivorDbContext _context;

    public CompetitorController(SurvivorDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompetitors()
    {
        var competitors = await _context.Competitors.ToListAsync();
        return Ok(competitors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompetitorById(int id)
    {
        var competitor = await _context.Competitors.FindAsync(id);
        if (competitor == null)
        {
            return NotFound();
        }
        return Ok(competitor);
    }

    [HttpGet("categories/{CategoryId}")]
    public async Task<IActionResult> GetCompetitorsByCategoryId(int CategoryId)
    {
        var competitors = await _context.Competitors.Where(c => c.CategoryId == CategoryId).ToListAsync();
        return Ok(competitors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompetitor([FromBody] CompetitorEntity competitor)
    {
        _context.Competitors.Add(competitor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCompetitorById), new { id = competitor.Id }, competitor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompetitor(int id, [FromBody] CompetitorEntity competitor)
    {
        if (id != competitor.Id)
        {
            return BadRequest();
        }

        _context.Entry(competitor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompetitor(int id)
    {
        var competitor = await _context.Competitors.FindAsync(id);
        if (competitor == null)
        {
            return NotFound();
        }

        _context.Competitors.Remove(competitor);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
