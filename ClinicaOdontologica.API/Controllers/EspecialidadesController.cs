using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class EspecialidadesController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public EspecialidadesController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/Especialidades
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Especialidades>>> GetEspecialidades()
    {
        return await _context.Especialidades.ToListAsync();
    }

    // GET: api/Especialidades/5
    [HttpGet("{id_especialidad}")]
    public async Task<ActionResult<Especialidades>> GetEspecialidades(int id_especialidad)
    {
        var especialidades = await _context.Especialidades.FindAsync(id_especialidad);

        if (especialidades == null)
        {
            return NotFound();
        }

        return especialidades;
    }

    // PUT: api/Especialidades/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id_especialidad}")]
    public async Task<IActionResult> PutEspecialidades(int? id_especialidad, Especialidades especialidades)
    {
        if (id_especialidad != especialidades.Id_Especialidad)
        {
            return BadRequest();
        }

        _context.Entry(especialidades).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EspecialidadesExists(id_especialidad))
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

    // POST: api/Especialidades
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Especialidades>> PostEspecialidades(Especialidades especialidades)
    {
        _context.Especialidades.Add(especialidades);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEspecialidades", new { id_especialidad = especialidades.Id_Especialidad }, especialidades);
    }

    // DELETE: api/Especialidades/5
    [HttpDelete("{id_especialidad}")]
    public async Task<IActionResult> DeleteEspecialidades(int? id_especialidad)
    {
        var especialidades = await _context.Especialidades.FindAsync(id_especialidad);
        if (especialidades == null)
        {
            return NotFound();
        }

        _context.Especialidades.Remove(especialidades);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EspecialidadesExists(int? id_especialidad)
    {
        return _context.Especialidades.Any(e => e.Id_Especialidad == id_especialidad);
    }
}
