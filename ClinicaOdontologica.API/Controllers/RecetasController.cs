using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class RecetasController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public RecetasController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Recetas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recetas>>> GetRecetas()
    {
        return await _context.Recetas.ToListAsync();
    }

    // GET: api/Recetas/5
    [HttpGet("{idreceta}")]
    public async Task<ActionResult<Recetas>> GetRecetas(int idreceta)
    {
        var recetas = await _context.Recetas.FindAsync(idreceta);

        if (recetas == null)
        {
            return NotFound();
        }

        return recetas;
    }

    // PUT: api/Recetas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idreceta}")]
    public async Task<IActionResult> PutRecetas(int? idreceta, Recetas recetas)
    {
        if (idreceta != recetas.IdReceta)
        {
            return BadRequest();
        }

        _context.Entry(recetas).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RecetasExists(idreceta))
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

    // POST: api/Recetas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Recetas>> PostRecetas(Recetas recetas)
    {
        _context.Recetas.Add(recetas);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRecetas", new { idreceta = recetas.IdReceta }, recetas);
    }

    // DELETE: api/Recetas/5
    [HttpDelete("{idreceta}")]
    public async Task<IActionResult> DeleteRecetas(int? idreceta)
    {
        var recetas = await _context.Recetas.FindAsync(idreceta);
        if (recetas == null)
        {
            return NotFound();
        }

        _context.Recetas.Remove(recetas);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RecetasExists(int? idreceta)
    {
        return _context.Recetas.Any(e => e.IdReceta == idreceta);
    }
}
