using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class DetallesCitasController : Controller
{
    // GET: DETALLESCITAS
    public ActionResult Index()
    {
        var detalleCita = CRUD<DetallesCita>.GetAll();
        return View(detalleCita);
    }

    // GET: DETALLESCITAS/Details/5
    public ActionResult Details(int iddetallecita)
    {
        var detalleCita = CRUD<DetallesCita>.GetById(iddetallecita);
        if (detalleCita == null)
        {
            return NotFound();
        }
        return View(detalleCita);
    }

    // GET: DETALLESCITAS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: DETALLESCITAS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(DetallesCita detallescita)
    {
        try
        {
            CRUD<DetallesCita>.Create(detallescita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallescita);
        }
    }

    // GET: DETALLESCITAS/Edit/5
    public ActionResult Edit(int iddetallecita)
    {
        var detalleCita = CRUD<DetallesCita>.GetById(iddetallecita);
        if (detalleCita == null)
        {
            return NotFound();
        }
        return View(detalleCita);
    }

    // POST: DETALLESCITAS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int iddetallecita, DetallesCita detallescita)
    {
        try
        {
            CRUD<DetallesCita>.Update(iddetallecita, detallescita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallescita);
        }
    }

    // GET: DETALLESCITAS/Delete/5
    public ActionResult Delete(int iddetallecita)
    {
        var detalleCita = CRUD<DetallesCita>.GetById(iddetallecita);
        if (detalleCita == null)
        {
            return NotFound();
        }
        return View(detalleCita);
    }

    // POST: DETALLESCITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int iddetallecita, DetallesCita detallescita)
    {
        try
        {
            CRUD<DetallesCita>.Delete(iddetallecita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}