using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProScape.Domain.Entities;

namespace ProScape.Web.ViewModels;

public class AmenityViewModel
{
    public Amenity? Amenity { get; set; }

    [ValidateNever]
    public IEnumerable<SelectListItem>? VillaList { get; set; }
}
