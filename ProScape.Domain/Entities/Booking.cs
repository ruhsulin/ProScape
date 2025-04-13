using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProScape.Domain.Entities;

public class Booking
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }


    [Required]
    public int VillaId { get; set; }
    [ForeignKey("VillaId")]
    public Villa Villa { get; set; }

    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    public string? Phone { get; set; }


    [Required]
    public double TotalCost { get; set; }
    public int Nights { get; set; }
    public string? Status { get; set; }


    [Required]
    public DateTime BookingDate { get; set; }
    [Required]
    public DateTime CheckInDate { get; set; }
    [Required]
    public DateTime CheckOutDate { get; set; }
}

