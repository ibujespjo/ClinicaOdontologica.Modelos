using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class CitasController : Controller //Herencia
{
    // GET: CITASS
    public ActionResult Index()
    {
        var Cita = CRUD<Citas>.GetAll();
        return View(Cita);
    }

    // GET: CITASS/Details/5
    public ActionResult Details(int idcita)
    {
        var cita=CRUD<Citas>.GetById(idcita);
        if(idcita==null)
        {
            return NotFound();
        }
        else
        {
            return View(cita);
        }
    }

    // GET: CITASS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CITASS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost] //Se encarga de que reaccione cuando el usuario decida guardar el dato
    [ValidateAntiForgeryToken] //Usamos para una validacion de seguridad
    public ActionResult Create(Citas citas)
    {
        try
        {
            CRUD<Citas>.Create(citas);
            return RedirectToAction(nameof(Index));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("",ex.Message);
            return View(citas);
        }
    }

    // GET: CITASS/Edit/5
    public ActionResult Edit(int idcita)
    {
        var cita = CRUD<Citas>.GetById(idcita);
        if (cita == null)
        {
            return NotFound();
        }
        return View(cita);
    }

    // POST: CITASS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idcita,Citas citas)
    {
        try
        {
            CRUD<Citas>.Update(idcita, citas);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(citas);
        }
    }

    // GET: CITASS/Delete/5
    public ActionResult Delete(int idcita)
    {
        var cita = CRUD<Citas>.GetById(idcita);
        if (cita == null)
        {
            return NotFound();
        }
        return View(cita);
    }

    // POST: CITASS/Delete/5
    [HttpPost, ActionName("Delete")] //
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idcita,Citas citas)
    {
        try
        { 
         CRUD<Citas>.Delete(idcita);
        return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }

}
