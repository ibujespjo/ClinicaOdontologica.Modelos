using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class RecetasController : Controller
{
    // GET: RECETASS
    public ActionResult Index()
    {
        var recetas = CRUD<Recetas>.GetAll();
        return View(recetas);
    }

    // GET: RECETASS/Details/5
    public ActionResult Details(int idreceta)
    {
        var receta = CRUD<Recetas>.GetById(idreceta);
        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // GET: RECETASS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: RECETASS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Recetas recetas)
    {
        try
        {
            CRUD<Recetas>.Create(recetas);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(recetas);
        }
    }

    // GET: RECETASS/Edit/5
    public ActionResult Edit(int idreceta)
    {
        var receta = CRUD<Recetas>.GetById(idreceta);
        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // POST: RECETASS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idreceta, Recetas recetas)
    {
        try
        {
            CRUD<Recetas>.Update(idreceta, recetas);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(recetas);
        }
    }

    // GET: RECETASS/Delete/5
    public ActionResult Delete(int idreceta)
    {
        var receta = CRUD<Recetas>.GetById(idreceta);
        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // POST: RECETASS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idreceta, Recetas recetas)
    {
        try
        {
            CRUD<Recetas>.Delete(idreceta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}