using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class TratamientosController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public TratamientosController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Tratamientos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tratamientos>>> GetTratamientos()
    {
        return await _context.Tratamientos.ToListAsync();
    }

    // GET: api/Tratamientos/5
    [HttpGet("{idtratamiento}")]
    public async Task<ActionResult<Tratamientos>> GetTratamientos(int idtratamiento)
    {
        var tratamientos = await _context.Tratamientos.FindAsync(idtratamiento);

        if (tratamientos == null)
        {
            return NotFound();
        }

        return tratamientos;
    }

    // PUT: api/Tratamientos/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idtratamiento}")]
    public async Task<IActionResult> PutTratamientos(int? idtratamiento, Tratamientos tratamientos)
    {
        if (idtratamiento != tratamientos.IdTratamiento)
        {
            return BadRequest();
        }

        _context.Entry(tratamientos).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TratamientosExists(idtratamiento))
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

    // POST: api/Tratamientos
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Tratamientos>> PostTratamientos(Tratamientos tratamientos)
    {
        _context.Tratamientos.Add(tratamientos);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTratamientos", new { idtratamiento = tratamientos.IdTratamiento }, tratamientos);
    }

    // DELETE: api/Tratamientos/5
    [HttpDelete("{idtratamiento}")]
    public async Task<IActionResult> DeleteTratamientos(int? idtratamiento)
    {
        var tratamientos = await _context.Tratamientos.FindAsync(idtratamiento);
        if (tratamientos == null)
        {
            return NotFound();
        }

        _context.Tratamientos.Remove(tratamientos);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TratamientosExists(int? idtratamiento)
    {
        return _context.Tratamientos.Any(e => e.IdTratamiento == idtratamiento);
    }
}
