using Microsoft.AspNetCore.Mvc;
using ProScape.Domain.Entities;
using ProScape.Infrastructure.Data;

namespace ProScape.Web.Controllers;

public class VillaController : Controller
{
    private readonly ApplicationDbContext _db;

    public VillaController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var villas = _db.Villas.ToList();
        return View(villas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Villa villa)
    {
        if (villa.Name == villa.Description)
        {
            ModelState.AddModelError("description", "The description cannot exactly match the name.");
        }

        if ((ModelState.IsValid))
        {
            _db.Villas.Add(villa);
            _db.SaveChanges();
            TempData["success"] = "The villa has been created successfully.";
            return RedirectToAction("Index", "Villa");
        }
        TempData["error"] = "The villa could not been created!";
        return View();
    }

    [HttpGet]
    public IActionResult Update(int villaId)
    {
        Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);

        if (obj is null)
        {
            return RedirectToAction("Error", "Home");
        }

        return View(obj);
    }

    [HttpPost]
    public IActionResult Update(Villa villa)
    {
        if ((ModelState.IsValid))
        {
            _db.Villas.Update(villa);
            _db.SaveChanges();
            TempData["success"] = "The villa has been updated successfully.";
            return RedirectToAction("Index", "Villa");
        }
        TempData["error"] = "The villa could not been updated!";
        return View();
    }

    [HttpGet]
    public IActionResult Delete(int villaId)
    {
        Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);

        if (obj is null)
        {
            return RedirectToAction("Error", "Home");
        }

        return View(obj);
    }

    [HttpPost]
    public IActionResult Delete(Villa villa)
    {
        Villa? objFromDb = _db.Villas.FirstOrDefault(u => u.Id == villa.Id);

        if (objFromDb is not null)
        {
            _db.Villas.Remove(objFromDb);
            _db.SaveChanges();
            TempData["success"] = "The villa has been deleted successfully.";
            return RedirectToAction("Index", "Villa");
        }
        TempData["error"] = "The villa could not been deleted!";
        return View();
    }
}
