using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class TratamientosController : Controller
{
    // GET: TRATAMIENTOSS
    public ActionResult Index()
    {
        var tratamientos = CRUD<Tratamientos>.GetAll();
        return View(tratamientos);
    }

    // GET: TRATAMIENTOSS/Details/5
    public ActionResult Details(int idtratamiento)
    {
        var tratamiento = CRUD<Tratamientos>.GetById(idtratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }
        return View(tratamiento);
    }

    // GET: TRATAMIENTOSS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: TRATAMIENTOSS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Tratamientos tratamientos)
    {
        try
        {
            CRUD<Tratamientos>.Create(tratamientos);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(tratamientos);
        }
    }

    // GET: TRATAMIENTOSS/Edit/5
    public ActionResult Edit(int idtratamiento)
    {
        var tratamiento = CRUD<Tratamientos>.GetById(idtratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }
        return View(tratamiento);
    }

    // POST: TRATAMIENTOSS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idtratamiento, Tratamientos tratamientos)
    {
        try
        {
            CRUD<Tratamientos>.Update(idtratamiento, tratamientos);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(tratamientos);
        }
    }

    // GET: TRATAMIENTOSS/Delete/5
    public ActionResult Delete(int idtratamiento)
    {
        var tratamiento = CRUD<Tratamientos>.GetById(idtratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }
        return View(tratamiento);
    }

    // POST: TRATAMIENTOSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idtratamiento, Tratamientos tratamientos)
    {
        try
        {
            CRUD<Tratamientos>.Delete(idtratamiento);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}