using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProScape.Domain.Entities;

public class VillaNumber
{
    // giving the unique id manually.
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "Villa Number")]
    public int Villa_Number { get; set; }

    [ForeignKey("Villa")]
    public int VillaId { get; set; }

    // Navigation property
    [ValidateNever]
    public Villa Villa { get; set; }

    public string? SpecialDetails { get; set; }
}
