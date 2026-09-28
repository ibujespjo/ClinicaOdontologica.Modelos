using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class ConsultoriosController : Controller
{
    // GET: CONSULTORIOSS
    public ActionResult Index()
    {
        var consultorios = CRUD<Consultorios>.GetAll();
        return View(consultorios);
    }

    // GET: CONSULTORIOSS/Details/5
    public ActionResult Details(int idconsultorio)
    {
        var consultorio = CRUD<Consultorios>.GetById(idconsultorio);
        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // GET: CONSULTORIOSS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CONSULTORIOSS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Consultorios consultorios)
    {
        try
        {
            CRUD<Consultorios>.Create(consultorios);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(consultorios);
        }
    }

    // GET: CONSULTORIOSS/Edit/5
    public ActionResult Edit(int idconsultorio)
    {
        var consultorio = CRUD<Consultorios>.GetById(idconsultorio);
        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // POST: CONSULTORIOSS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idconsultorio, Consultorios consultorios)
    {
        try
        {
            CRUD<Consultorios>.Update(idconsultorio, consultorios);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(consultorios);
        }
    }

    // GET: CONSULTORIOSS/Delete/5
    public ActionResult Delete(int idconsultorio)
    {
        var consultorio = CRUD<Consultorios>.GetById(idconsultorio);
        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // POST: CONSULTORIOSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idconsultorio, Consultorios consultorios)
    {
        try
        {
            CRUD<Consultorios>.Delete(idconsultorio);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}