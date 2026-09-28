using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;

public class FacturasController : Controller
{
    // GET: FACTURASS
    public ActionResult Index()
    {
        var facturas = CRUD<Facturas>.GetAll();
        return View(facturas);
    }

    // GET: FACTURASS/Details/5
    public ActionResult Details(int idfactura)
    {
        var factura = CRUD<Facturas>.GetById(idfactura);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // GET: FACTURASS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: FACTURASS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Facturas facturas)
    {
        try
        {
            CRUD<Facturas>.Create(facturas);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(facturas);
        }
    }

    // GET: FACTURASS/Edit/5
    public ActionResult Edit(int idfactura)
    {
        var factura = CRUD<Facturas>.GetById(idfactura);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // POST: FACTURASS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idfactura, Facturas facturas)
    {
        try
        {
            CRUD<Facturas>.Update(idfactura, facturas);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(facturas);
        }
    }

    // GET: FACTURASS/Delete/5
    public ActionResult Delete(int idfactura)
    {
        var factura = CRUD<Facturas>.GetById(idfactura);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // POST: FACTURASS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idfactura, Facturas facturas)
    {
        try
        {
            CRUD<Facturas>.Delete(idfactura);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}