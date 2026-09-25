using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class ConsultoriosController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public ConsultoriosController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Consultorios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consultorios>>> GetConsultorios()
    {
        return await _context.Consultorios.ToListAsync();
    }

    // GET: api/Consultorios/5
    [HttpGet("{idconsultorio}")]
    public async Task<ActionResult<Consultorios>> GetConsultorios(int idconsultorio)
    {
        var consultorios = await _context.Consultorios.FindAsync(idconsultorio);

        if (consultorios == null)
        {
            return NotFound();
        }

        return consultorios;
    }

    // PUT: api/Consultorios/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idconsultorio}")]
    public async Task<IActionResult> PutConsultorios(int? idconsultorio, Consultorios consultorios)
    {
        if (idconsultorio != consultorios.IdConsultorio)
        {
            return BadRequest();
        }

        _context.Entry(consultorios).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsultoriosExists(idconsultorio))
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

    // POST: api/Consultorios
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Consultorios>> PostConsultorios(Consultorios consultorios)
    {
        _context.Consultorios.Add(consultorios);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsultorios", new { idconsultorio = consultorios.IdConsultorio }, consultorios);
    }

    // DELETE: api/Consultorios/5
    [HttpDelete("{idconsultorio}")]
    public async Task<IActionResult> DeleteConsultorios(int? idconsultorio)
    {
        var consultorios = await _context.Consultorios.FindAsync(idconsultorio);
        if (consultorios == null)
        {
            return NotFound();
        }

        _context.Consultorios.Remove(consultorios);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsultoriosExists(int? idconsultorio)
    {
        return _context.Consultorios.Any(e => e.IdConsultorio == idconsultorio);
    }
}
