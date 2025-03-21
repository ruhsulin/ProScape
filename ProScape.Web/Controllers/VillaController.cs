using Microsoft.AspNetCore.Mvc;
using ProScape.Application.Common.Interfaces;
using ProScape.Domain.Entities;

namespace ProScape.Web.Controllers;

public class VillaController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        var villas = _unitOfWork.Villa.GetAll();
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

        if (ModelState.IsValid)
        {
            if (villa.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"img/VillaImages");

                using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    villa.Image.CopyTo(fileStream);

                villa.ImageUrl = @"\img\VillaImages\" + fileName;

            }
            else
            {
                villa.ImageUrl = "https://placeholder.co/600x400";
            }

            _unitOfWork.Villa.Add(villa);
            _unitOfWork.Save();
            TempData["success"] = "The villa has been created successfully.";
            return RedirectToAction("Index", "Villa");
        }
        TempData["error"] = "The villa could not been created!";
        return View();
    }

    [HttpGet]
    public IActionResult Update(int villaId)
    {
        Villa? obj = _unitOfWork.Villa.Get(u => u.Id == villaId);

        if (obj is null)
        {
            return RedirectToAction("Error", "Home");
        }

        return View(obj);
    }

    [HttpPost]
    public IActionResult Update(Villa villa)
    {
        if (ModelState.IsValid && villa.Id > 0)
        {
            _unitOfWork.Villa.Update(villa);
            _unitOfWork.Save();
            TempData["success"] = "The villa has been updated successfully.";
            return RedirectToAction("Index", "Villa");
        }

        TempData["error"] = "The villa could not been updated!";
        return View();
    }

    [HttpGet]
    public IActionResult Delete(int villaId)
    {
        Villa? obj = _unitOfWork.Villa.Get(u => u.Id == villaId);

        if (obj is null)
        {
            return RedirectToAction("Error", "Home");
        }

        return View(obj);
    }

    [HttpPost]
    public IActionResult Delete(Villa villa)
    {
        Villa? objFromDb = _unitOfWork.Villa.Get(u => u.Id == villa.Id);

        if (objFromDb is not null)
        {
            _unitOfWork.Villa.Remove(objFromDb);
            _unitOfWork.Save();
            TempData["success"] = "The villa has been deleted successfully.";
            return RedirectToAction("Index", "Villa");
        }

        TempData["error"] = "The villa could not been deleted!";
        return View();
    }
}
