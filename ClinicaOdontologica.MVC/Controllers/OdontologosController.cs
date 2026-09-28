using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class OdontologosController : Controller
{
    // GET: ODONTOLOGOSS
    public ActionResult Index()
    {
        var odontologos = CRUD<Odontologos>.GetAll();
        return View(odontologos);
    }

    // GET: ODONTOLOGOSS/Details/5
    public ActionResult Details(int idodontologo)
    {
        var odontologo = CRUD<Odontologos>.GetById(idodontologo);
        if (odontologo == null)
        {
            return NotFound();
        }
        return View(odontologo);
    }

    // GET: ODONTOLOGOSS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ODONTOLOGOSS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Odontologos odontologos)
    {
        try
        {
            CRUD<Odontologos>.Create(odontologos);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(odontologos);
        }
    }

    // GET: ODONTOLOGOSS/Edit/5
    public ActionResult Edit(int idodontologo)
    {
        var odontologo = CRUD<Odontologos>.GetById(idodontologo);
        if (odontologo == null)
        {
            return NotFound();
        }
        return View(odontologo);
    }

    // POST: ODONTOLOGOSS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idodontologo, Odontologos odontologos)
    {
        try
        {
            CRUD<Odontologos>.Update(idodontologo, odontologos);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(odontologos);
        }
    }

    // GET: ODONTOLOGOSS/Delete/5
    public ActionResult Delete(int idodontologo)
    {
        var odontologo = CRUD<Odontologos>.GetById(idodontologo);
        if (odontologo == null)
        {
            return NotFound();
        }
        return View(odontologo);
    }

    // POST: ODONTOLOGOSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idodontologo, Odontologos odontologos)
    {
        try
        {
            CRUD<Odontologos>.Delete(idodontologo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}