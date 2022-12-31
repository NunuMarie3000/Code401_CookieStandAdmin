using CookieStandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CookieStandAPI.Data
{

  public class CookieStandDbContext: DbContext
  {
    public DbSet<CookieStand> CookieStands { get; set; }

    public CookieStandDbContext( DbContextOptions options ) : base(options)
    {

    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
      //modelBuilder.Entity<class>().HasData(thedata);
    }

  }
}

