using Microsoft.EntityFrameworkCore;
using System;

namespace Parks.Models
{
  public class ParksContext : DbContext
  {
    public ParksContext()
    {

    }
    public ParksContext(DbContextOptions<ParksContext> options)
        : base(options)
    {

    }

    public DbSet<Park> Parks { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
          .HasData(
              new Park { ParkId = -1, TypeOfPark = "State",  City = "Pouslbo", State = "WA",  Name = "Kitsap Memorial State Park", Description = "Kitsap Memorial State Park is a 63-acre public recreation area located on Hood Canal, seven miles north of Poulsbo in Kitsap County, Washington." },
              new Park { ParkId = -2, TypeOfPark = "State",  City = "Brinnon", State = "WA",  Name = "Dosewallips State Park", Description = "Dosewallips State Park is a public recreation area located where the Dosewallips River empties into Hood Canal in Jefferson County, Washington." },
              new Park { ParkId = -3, TypeOfPark = "National",  City = "Port Angeles", State = "WA",  Name = "Olympic National Park", Description = "Olympic National Park is on Washington's Olympic Peninsula in the Pacific Northwest. The park sprawls across several different ecosystems, from the dramatic peaks of the Olympic Mountains to old-growth forests." },
              new Park { ParkId = -4, TypeOfPark = "National",  City = "Lake Chelan", State = "WA",  Name = "North Cascades National Park", Description = "North Cascades National Park is in northern Washington State. It’s a vast wilderness of conifer-clad mountains, glaciers and lakes." },
              new Park { ParkId = -5, TypeOfPark = "National",  City = "Mount Rainier", State = "WA",  Name = "Mount Rainier National Park", Description = "Mount Rainier National Park, a 369-sq.-mile Washington state reserve southeast of Seattle, surrounds glacier-capped, 14,410-ft. Mount Rainier." }
          );
      
    }
  }
}