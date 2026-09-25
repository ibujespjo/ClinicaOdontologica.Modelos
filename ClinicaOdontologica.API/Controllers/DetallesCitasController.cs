using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class DetallesCitasController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public DetallesCitasController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/DetallesCita
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetallesCita>>> GetDetallesCita()
    {
        return await _context.DetallesCita.ToListAsync();
    }

    // GET: api/DetallesCita/5
    [HttpGet("{iddetallecita}")]
    public async Task<ActionResult<DetallesCita>> GetDetallesCita(int iddetallecita)
    {
        var detallescita = await _context.DetallesCita.FindAsync(iddetallecita);

        if (detallescita == null)
        {
            return NotFound();
        }

        return detallescita;
    }

    // PUT: api/DetallesCita/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{iddetallecita}")]
    public async Task<IActionResult> PutDetallesCita(int? iddetallecita, DetallesCita detallescita)
    {
        if (iddetallecita != detallescita.IdDetalleCita)
        {
            return BadRequest();
        }

        _context.Entry(detallescita).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DetallesCitaExists(iddetallecita))
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

    // POST: api/DetallesCita
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<DetallesCita>> PostDetallesCita(DetallesCita detallescita)
    {
        _context.DetallesCita.Add(detallescita);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDetallesCita", new { iddetallecita = detallescita.IdDetalleCita }, detallescita);
    }

    // DELETE: api/DetallesCita/5
    [HttpDelete("{iddetallecita}")]
    public async Task<IActionResult> DeleteDetallesCita(int? iddetallecita)
    {
        var detallescita = await _context.DetallesCita.FindAsync(iddetallecita);
        if (detallescita == null)
        {
            return NotFound();
        }

        _context.DetallesCita.Remove(detallescita);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DetallesCitaExists(int? iddetallecita)
    {
        return _context.DetallesCita.Any(e => e.IdDetalleCita == iddetallecita);
    }
}
