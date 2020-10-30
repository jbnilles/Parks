using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Parks.Models
{
    public class Park
    {
    [Required]
    public int ParkId { get; set; }
    [Required]
    public bool IsStatePark { get; set; }
    
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    
    
    }
}