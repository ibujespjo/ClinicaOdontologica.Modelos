using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class PacientesController : Controller
{
    // GET: PACIENTESS
    public ActionResult Index()
    {
        var pacientes = CRUD<Pacientes>.GetAll();
        return View(pacientes);
    }

    // GET: PACIENTESS/Details/5
    public ActionResult Details(int idpaciente)
    {
        var paciente = CRUD<Pacientes>.GetById(idpaciente);
        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // GET: PACIENTESS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PACIENTESS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Pacientes pacientes)
    {
        try
        {
            CRUD<Pacientes>.Create(pacientes);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(pacientes);
        }
    }

    // GET: PACIENTESS/Edit/5
    public ActionResult Edit(int idpaciente)
    {
        var paciente = CRUD<Pacientes>.GetById(idpaciente);
        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // POST: PACIENTESS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idpaciente, Pacientes pacientes)
    {
        try
        {
            CRUD<Pacientes>.Update(idpaciente, pacientes);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(pacientes);
        }
    }

    // GET: PACIENTESS/Delete/5
    public ActionResult Delete(int idpaciente)
    {
        var paciente = CRUD<Pacientes>.GetById(idpaciente);
        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // POST: PACIENTESS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idpaciente, Pacientes pacientes)
    {
        try
        {
            CRUD<Pacientes>.Delete(idpaciente);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}