using System.ComponentModel.DataAnnotations;
namespace Parks.Models
{
    public class Park
    {
    [Required]
    public int ParkId { get; set; }
    [Required]
    public string TypeOfPark { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    }
}