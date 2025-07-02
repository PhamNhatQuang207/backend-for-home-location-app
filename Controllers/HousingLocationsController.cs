// Controllers/HousingLocationsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HousingAPI.Models;
using HousingAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class HousingLocationsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public HousingLocationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/HousingLocations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HousingLocation>>> GetHousingLocations()
    {
        return await _context.HousingLocations.ToListAsync();
    }

    // GET: api/HousingLocations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HousingLocation>> GetHousingLocation(int id)
    {
        var housingLocation = await _context.HousingLocations.FindAsync(id);

        if (housingLocation == null)
        {
            return NotFound();
        }

        return housingLocation;
    }

    // POST: api/HousingLocations
    [HttpPost]
    public async Task<ActionResult<HousingLocation>> PostHousingLocation(HousingLocation housingLocation)
    {
        _context.HousingLocations.Add(housingLocation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetHousingLocation), new { id = housingLocation.Id }, housingLocation);
    }

    // PUT: api/HousingLocations/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHousingLocation(int id, HousingLocation housingLocation)
    {
        if (id != housingLocation.Id)
        {
            return BadRequest();
        }

        _context.Entry(housingLocation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HousingLocationExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/HousingLocations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHousingLocation(int id)
    {
        var housingLocation = await _context.HousingLocations.FindAsync(id);
        if (housingLocation == null)
        {
            return NotFound();
        }

        _context.HousingLocations.Remove(housingLocation);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HousingLocationExists(int id)
    {
        return _context.HousingLocations.Any(e => e.Id == id);
    }
}