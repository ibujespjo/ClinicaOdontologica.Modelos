using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class PacientesController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public PacientesController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Pacientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pacientes>>> GetPacientes()
    {
        return await _context.Pacientes.ToListAsync();
    }

    // GET: api/Pacientes/5
    [HttpGet("{idpaciente}")]
    public async Task<ActionResult<Pacientes>> GetPacientes(int idpaciente)
    {
        var pacientes = await _context.Pacientes.FindAsync(idpaciente);

        if (pacientes == null)
        {
            return NotFound();
        }

        return pacientes;
    }

    // PUT: api/Pacientes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idpaciente}")]
    public async Task<IActionResult> PutPacientes(int? idpaciente, Pacientes pacientes)
    {
        if (idpaciente != pacientes.IdPaciente)
        {
            return BadRequest();
        }

        _context.Entry(pacientes).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PacientesExists(idpaciente))
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

    // POST: api/Pacientes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Pacientes>> PostPacientes(Pacientes pacientes)
    {
        _context.Pacientes.Add(pacientes);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPacientes", new { idpaciente = pacientes.IdPaciente }, pacientes);
    }

    // DELETE: api/Pacientes/5
    [HttpDelete("{idpaciente}")]
    public async Task<IActionResult> DeletePacientes(int? idpaciente)
    {
        var pacientes = await _context.Pacientes.FindAsync(idpaciente);
        if (pacientes == null)
        {
            return NotFound();
        }

        _context.Pacientes.Remove(pacientes);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PacientesExists(int? idpaciente)
    {
        return _context.Pacientes.Any(e => e.IdPaciente == idpaciente);
    }
}
