using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProScape.Application.Common.Interfaces;
using ProScape.Domain.Entities;
using ProScape.Web.ViewModels;

namespace ProScape.Web.Controllers;

public class AmenityController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AmenityController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var amenities = _unitOfWork.Amenity.GetAll(includeProperties: "Villa");
        return View(amenities);
    }

    public IActionResult Create()
    {
        AmenityViewModel amenityViewModel = new()
        {
            VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            })
        };

        return View(amenityViewModel);
    }

    [HttpPost]
    public IActionResult Create(AmenityViewModel obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Amenity.Add(obj.Amenity);
            _unitOfWork.Save();
            TempData["success"] = "The amenity has been created successfully.";
            return RedirectToAction("Index", "Amenity");
        }
        TempData["error"] = "The villa number could not been created!";

        obj.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString(),
        });

        return View(obj);
    }

    [HttpGet]
    public IActionResult Update(int amenityId)
    {
        AmenityViewModel amenityViewModel = new()
        {
            VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            }),
            Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
        };

        if (amenityViewModel.Amenity is null)
        {
            return RedirectToAction("Error", "Home");
        }

        return View(amenityViewModel);
    }

    [HttpPost]
    public IActionResult Update(AmenityViewModel amenityVM)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Amenity.Update(amenityVM.Amenity);
            _unitOfWork.Save();
            TempData["success"] = "The amenity has been updated successfully.";
            return RedirectToAction("Index", "Amenity");
        }
        TempData["error"] = "The amenity could not been updated!";

        amenityVM.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString(),
        });

        return View(amenityVM);
    }

    [HttpGet]
    public IActionResult Delete(int amenityId)
    {
        AmenityViewModel amenityViewModel = new()
        {
            VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            }),
            Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
        };

        if (amenityViewModel.Amenity is null)
        {
            return RedirectToAction("Error", "Home");
        }

        return View(amenityViewModel);
    }

    [HttpPost]
    public IActionResult Delete(AmenityViewModel amenityVM)
    {
        Amenity? objFromDb = _unitOfWork.Amenity.Get(u => u.Id == amenityVM.Amenity.Id);

        if (objFromDb is not null)
        {
            _unitOfWork.Amenity.Remove(objFromDb);
            _unitOfWork.Save();
            TempData["success"] = "The amenity has been deleted successfully.";
            return RedirectToAction(nameof(Index), "Amenity");
        }
        TempData["error"] = "The amenity could not been deleted!";
        return View();
    }
}
