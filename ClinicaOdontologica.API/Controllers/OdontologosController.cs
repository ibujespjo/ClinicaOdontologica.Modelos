using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class OdontologosController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public OdontologosController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Odontologos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Odontologos>>> GetOdontologos()
    {
        return await _context.Odontologos.ToListAsync();
    }

    // GET: api/Odontologos/5
    [HttpGet("{idodontologo}")]
    public async Task<ActionResult<Odontologos>> GetOdontologos(int idodontologo)
    {
        var odontologos = await _context.Odontologos.FindAsync(idodontologo);

        if (odontologos == null)
        {
            return NotFound();
        }

        return odontologos;
    }

    // PUT: api/Odontologos/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idodontologo}")]
    public async Task<IActionResult> PutOdontologos(int? idodontologo, Odontologos odontologos)
    {
        if (idodontologo != odontologos.IdOdontologo)
        {
            return BadRequest();
        }

        _context.Entry(odontologos).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OdontologosExists(idodontologo))
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

    // POST: api/Odontologos
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Odontologos>> PostOdontologos(Odontologos odontologos)
    {
        _context.Odontologos.Add(odontologos);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetOdontologos", new { idodontologo = odontologos.IdOdontologo }, odontologos);
    }

    // DELETE: api/Odontologos/5
    [HttpDelete("{idodontologo}")]
    public async Task<IActionResult> DeleteOdontologos(int? idodontologo)
    {
        var odontologos = await _context.Odontologos.FindAsync(idodontologo);
        if (odontologos == null)
        {
            return NotFound();
        }

        _context.Odontologos.Remove(odontologos);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OdontologosExists(int? idodontologo)
    {
        return _context.Odontologos.Any(e => e.IdOdontologo == idodontologo);
    }
}
