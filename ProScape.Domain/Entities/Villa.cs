using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProScape.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(255)]
        public required string Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Price per night")]
        [Range(10, 500)]
        public double Price { get; set; }

        [Display(Name = "Square Foot")]
        public int Sqft { get; set; }

        [Display(Name = "Occupancy")]
        public int Occupancy { get; set; }

        [NotMapped] //don't add to database
        public IFormFile? Image { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // navigation property to get all amenities for villa. 
        // One villa can have multiple amenities
        [ValidateNever]
        public IEnumerable<Amenity> VillaAmenity { get; set; }
    }
}
