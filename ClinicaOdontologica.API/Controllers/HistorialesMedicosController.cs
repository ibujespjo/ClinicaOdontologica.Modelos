using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaOdontologica.Modelos;

[Route("api/[controller]")]
[ApiController]
public class HistorialesMedicosController : ControllerBase
{
    private readonly ClinicaOdontologicaAPIContext _context;
    public HistorialesMedicosController(ClinicaOdontologicaAPIContext context)
    {
        _context = context;
    }

    // GET: api/HistorialesMedicos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HistorialesMedicos>>> GetHistorialesMedicos()
    {
        return await _context.HistorialesMedicos.ToListAsync();
    }

    // GET: api/HistorialesMedicos/5
    [HttpGet("{idhistorial}")]
    public async Task<ActionResult<HistorialesMedicos>> GetHistorialesMedicos(int idhistorial)
    {
        var historialesmedicos = await _context.HistorialesMedicos.FindAsync(idhistorial);

        if (historialesmedicos == null)
        {
            return NotFound();
        }

        return historialesmedicos;
    }

    // PUT: api/HistorialesMedicos/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idhistorial}")]
    public async Task<IActionResult> PutHistorialesMedicos(int? idhistorial, HistorialesMedicos historialesmedicos)
    {
        if (idhistorial != historialesmedicos.IdHistorial)
        {
            return BadRequest();
        }

        _context.Entry(historialesmedicos).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HistorialesMedicosExists(idhistorial))
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

    // POST: api/HistorialesMedicos
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<HistorialesMedicos>> PostHistorialesMedicos(HistorialesMedicos historialesmedicos)
    {
        _context.HistorialesMedicos.Add(historialesmedicos);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetHistorialesMedicos", new { idhistorial = historialesmedicos.IdHistorial }, historialesmedicos);
    }

    // DELETE: api/HistorialesMedicos/5
    [HttpDelete("{idhistorial}")]
    public async Task<IActionResult> DeleteHistorialesMedicos(int? idhistorial)
    {
        var historialesmedicos = await _context.HistorialesMedicos.FindAsync(idhistorial);
        if (historialesmedicos == null)
        {
            return NotFound();
        }

        _context.HistorialesMedicos.Remove(historialesmedicos);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HistorialesMedicosExists(int? idhistorial)
    {
        return _context.HistorialesMedicos.Any(e => e.IdHistorial == idhistorial);
    }
}
