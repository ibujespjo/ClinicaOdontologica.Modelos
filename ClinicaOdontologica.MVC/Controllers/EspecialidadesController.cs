using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class EspecialidadesController : Controller
{
    // GET: ESPECIALIDADESS
    public ActionResult Index()
    {
        var especialidades = CRUD<Especialidades>.GetAll();
        return View(especialidades);
    }

    // GET: ESPECIALIDADESS/Details/5
    public ActionResult Details(int id_especialidad)
    {
        var especialidades = CRUD<Especialidades>.GetById(id_especialidad);
        if (especialidades == null)
        {
            return NotFound();
        }
        return View(especialidades);
    }

    // GET: ESPECIALIDADESS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ESPECIALIDADESS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Especialidades especialidades)
    {
        try
        {
            CRUD<Especialidades>.Create(especialidades);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidades);
        }
    }

    // GET: ESPECIALIDADESS/Edit/5
    public ActionResult Edit(int id_especialidad)
    {
        var especialidades = CRUD<Especialidades>.GetById(id_especialidad);
        if (especialidades == null)
        {
            return NotFound();
        }
        return View(especialidades);
    }

    // POST: ESPECIALIDADESS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_especialidad, Especialidades especialidades)
    {
        try
        {
            CRUD<Especialidades>.Update(id_especialidad, especialidades);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidades);
        }
    }

    // GET: ESPECIALIDADESS/Delete/5
    public ActionResult Delete(int id_especialidad)
    {
        var especialidades = CRUD<Especialidades>.GetById(id_especialidad);
        if (especialidades == null)
        {
            return NotFound();
        }
        return View(especialidades);
    }

    // POST: ESPECIALIDADESS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id_especialidad, Especialidades especialidades)
    {
        try
        {
            CRUD<Especialidades>.Delete(id_especialidad);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}