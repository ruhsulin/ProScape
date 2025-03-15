using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProScape.Domain.Entities;
using ProScape.Infrastructure.Data;
using ProScape.Web.ViewModels;

namespace ProScape.Web.Controllers;

public class VillaNumberController : Controller
{
    private readonly ApplicationDbContext _db;

    public VillaNumberController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var villaNumbers = _db.VillaNumbers.Include(u => u.Villa).ToList();
        return View(villaNumbers);
    }

    public IActionResult Create()
    {
        VillaNumberViewModel villaNumberViewModel = new()
        {
            VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            })
        };

        return View(villaNumberViewModel);
    }

    [HttpPost]
    public IActionResult Create(VillaNumberViewModel obj)
    {
        bool roomNumberExists = _db.VillaNumbers.Any(u => u.Villa_Number == obj.VillaNumber.Villa_Number);


        if (ModelState.IsValid && !roomNumberExists)
        {
            _db.VillaNumbers.Add(obj.VillaNumber);
            _db.SaveChanges();
            TempData["success"] = "The villa number has been created successfully.";
            return RedirectToAction("Index", "VillaNumber");
        }
        TempData["error"] = "The villa number could not been created!";


        if (roomNumberExists)
        {
            TempData["error"] = "The villa is already created!";
        }

        obj.VillaList = _db.Villas.ToList().Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString(),
        });

        return View(obj);
    }

    [HttpGet]
    public IActionResult Update(int villaNumberId)
    {
        VillaNumberViewModel villaNumberViewModel = new()
        {
            VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            }),
            VillaNumber = _db.VillaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberId)
        };

        if (villaNumberViewModel.VillaNumber is null)
        {
            return RedirectToAction("Error", "Home");
        }

        return View(villaNumberViewModel);
    }

    [HttpPost]
    public IActionResult Update(VillaNumberViewModel villaNumberVM)
    {
        if (ModelState.IsValid)
        {
            _db.VillaNumbers.Update(villaNumberVM.VillaNumber);
            _db.SaveChanges();
            TempData["success"] = "The villa number has been updated successfully.";
            return RedirectToAction("Index", "VillaNumber");
        }
        TempData["error"] = "The villa number could not been updated!";

        villaNumberVM.VillaList = _db.Villas.ToList().Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString(),
        });

        return View(villaNumberVM);
    }

    [HttpGet]
    public IActionResult Delete(int villaNumberId)
    {
        VillaNumberViewModel villaNumberViewModel = new()
        {
            VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            }),
            VillaNumber = _db.VillaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberId)
        };

        if (villaNumberViewModel.VillaNumber is null)
        {
            return RedirectToAction("Error", "Home");
        }

        return View(villaNumberViewModel);
    }

    [HttpPost]
    public IActionResult Delete(VillaNumberViewModel villaNumberVM)
    {
        VillaNumber? objFromDb = _db.VillaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);

        if (objFromDb is not null)
        {
            _db.VillaNumbers.Remove(objFromDb);
            _db.SaveChanges();
            TempData["success"] = "The villa number has been deleted successfully.";
            return RedirectToAction(nameof(Index), "VillaNumber");
        }
        TempData["error"] = "The villa number could not been deleted!";
        return View();
    }
}
