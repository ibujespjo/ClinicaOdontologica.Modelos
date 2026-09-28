using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class HistorialesMedicosController : Controller
{
    // GET: HISTORIALESMEDICOSS
    public ActionResult Index()
    {
        var historial = CRUD<HistorialesMedicos>.GetAll();
        return View(historial);
    }

    // GET: HISTORIALESMEDICOSS/Details/5
    public ActionResult Details(int idhistorial)
    {
        var historial = CRUD<HistorialesMedicos>.GetById(idhistorial);
        if (historial == null)
        {
            return NotFound();
        }
        return View(historial);
    }

    // GET: HISTORIALESMEDICOSS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: HISTORIALESMEDICOSS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(HistorialesMedicos historialesmedicos)
    {
        try
        {
            CRUD<HistorialesMedicos>.Create(historialesmedicos);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialesmedicos);
        }
    }

    // GET: HISTORIALESMEDICOSS/Edit/5
    public ActionResult Edit(int idhistorial)
    {
        var historial = CRUD<HistorialesMedicos>.GetById(idhistorial);
        if (historial == null)
        {
            return NotFound();
        }
        return View(historial);
    }

    // POST: HISTORIALESMEDICOSS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idhistorial, HistorialesMedicos historialesmedicos)
    {
        try
        {
            CRUD<HistorialesMedicos>.Update(idhistorial, historialesmedicos);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialesmedicos);
        }
    }

    // GET: HISTORIALESMEDICOSS/Delete/5
    public ActionResult Delete(int idhistorial)
    {
        var historial = CRUD<HistorialesMedicos>.GetById(idhistorial);
        if (historial == null)
        {
            return NotFound();
        }
        return View(historial);
    }

    // POST: HISTORIALESMEDICOSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idhistorial, HistorialesMedicos historialesmedicos)
    {
        try
        {
            CRUD<HistorialesMedicos>.Delete(idhistorial);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}