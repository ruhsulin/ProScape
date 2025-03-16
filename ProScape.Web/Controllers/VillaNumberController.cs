using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProScape.Application.Common.Interfaces;
using ProScape.Domain.Entities;
using ProScape.Web.ViewModels;

namespace ProScape.Web.Controllers;

public class VillaNumberController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public VillaNumberController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var villaNumbers = _unitOfWork.VillaNumber.GetAll(includeProperties: "Villa");
        return View(villaNumbers);
    }

    public IActionResult Create()
    {
        VillaNumberViewModel villaNumberViewModel = new()
        {
            VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
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
        bool roomNumberExists = _unitOfWork.VillaNumber.Any(u => u.Villa_Number == obj.VillaNumber.Villa_Number);


        if (ModelState.IsValid && !roomNumberExists)
        {
            _unitOfWork.VillaNumber.Add(obj.VillaNumber);
            _unitOfWork.Save();
            TempData["success"] = "The villa number has been created successfully.";
            return RedirectToAction("Index", "VillaNumber");
        }
        TempData["error"] = "The villa number could not been created!";


        if (roomNumberExists)
        {
            TempData["error"] = "The villa is already created!";
        }

        obj.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
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
            VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            }),
            VillaNumber = _unitOfWork.VillaNumber.Get(u => u.Villa_Number == villaNumberId)
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
            _unitOfWork.VillaNumber.Update(villaNumberVM.VillaNumber);
            _unitOfWork.Save();
            TempData["success"] = "The villa number has been updated successfully.";
            return RedirectToAction("Index", "VillaNumber");
        }
        TempData["error"] = "The villa number could not been updated!";

        villaNumberVM.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
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
            VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            }),
            VillaNumber = _unitOfWork.VillaNumber.Get(u => u.Villa_Number == villaNumberId)
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
        VillaNumber? objFromDb = _unitOfWork.VillaNumber.Get(u => u.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);

        if (objFromDb is not null)
        {
            _unitOfWork.VillaNumber.Remove(objFromDb);
            _unitOfWork.Save();
            TempData["success"] = "The villa number has been deleted successfully.";
            return RedirectToAction(nameof(Index), "VillaNumber");
        }
        TempData["error"] = "The villa number could not been deleted!";
        return View();
    }
}
