using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class CitasController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public CitasController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Citas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Citas>>> GetCitas()
    {
        return await _context.Citas.ToListAsync();
    }

    // GET: api/Citas/5
    [HttpGet("{idcita}")]
    public async Task<ActionResult<Citas>> GetCitas(int idcita)
    {
        var citas = await _context.Citas.FindAsync(idcita);

        if (citas == null)
        {
            return NotFound();
        }

        return citas;
    }

    // PUT: api/Citas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idcita}")]
    public async Task<IActionResult> PutCitas(int? idcita, Citas citas)
    {
        if (idcita != citas.IdCita)
        {
            return BadRequest();
        }

        _context.Entry(citas).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CitasExists(idcita))
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

    // POST: api/Citas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Citas>> PostCitas(Citas citas)
    {
        _context.Citas.Add(citas);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCitas", new { idcita = citas.IdCita }, citas);
    }

    // DELETE: api/Citas/5
    [HttpDelete("{idcita}")]
    public async Task<IActionResult> DeleteCitas(int? idcita)
    {
        var citas = await _context.Citas.FindAsync(idcita);
        if (citas == null)
        {
            return NotFound();
        }

        _context.Citas.Remove(citas);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CitasExists(int? idcita)
    {
        return _context.Citas.Any(e => e.IdCita == idcita);
    }
}
