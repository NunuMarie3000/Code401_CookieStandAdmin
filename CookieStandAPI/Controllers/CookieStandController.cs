using CookieStandAPI.Data;
using CookieStandAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace CookieStandAPI.Controllers
{
  public class CookieStandController: Controller
  {
    private readonly CookieStandDbContext _context;
    public CookieStandController( CookieStandDbContext context )
    {
      _context = context;
    }
    public string Index()
    {
      //return View();
      return "This is the index route";
    }

    // post route
    [HttpPost]
    [Route("api/cookiestand")]
    public async Task<IActionResult> CreateCookieStand( CookieStand cookieStand )
    {
      //[Bind("Location,Description,Minimum_Customers_Per_Hour,Maximum_Customers_Per_Hour,Average_Cookies_Per_Sale,Owner")]
      //cookieStand.Id = Guid.NewGuid().ToString();
      if (cookieStand.Description == null)
      {
        cookieStand.Description = "";
      }

      if (ModelState.IsValid)
      {
        _context.CookieStands.Add(cookieStand);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCookieStand), new { id = cookieStand.Id }, cookieStand);
      }
      return StatusCode(500);
    }

    [HttpGet]
    [Route("api/cookiestand/{id}")]
    public CookieStand GetCookieStand( string id )
    {
      var cookiestand = _context.CookieStands.FirstOrDefault(x => x.Id == id);

      if (cookiestand == null)
      {
        return null;
      }

      return cookiestand;
    }

    [HttpGet]
    [Route("api/cookiestands")]
    public IEnumerable<CookieStand> GetCookieStands()
    {
      var cookieStands = _context.CookieStands.ToArray();

      return cookieStands;
    }

    [HttpPut]
    [Route("api/cookiestand/{id}")]
    public CookieStand UpdateCookieStand( string id, [FromBody] CookieStand cookieStand )
    {
      var chosenCS = _context.CookieStands.Where(cs => cs.Id == id).FirstOrDefault();
      if (chosenCS == null)
        return null;

      chosenCS.Location = cookieStand.Location;
      chosenCS.Minimum_Customers_Per_Hour = cookieStand.Minimum_Customers_Per_Hour;
      chosenCS.Maximum_Customers_Per_Hour = cookieStand.Maximum_Customers_Per_Hour;
      chosenCS.Average_Cookies_Per_Sale = cookieStand.Maximum_Customers_Per_Hour;
      chosenCS.Owner = cookieStand.Owner;
      chosenCS.Description = cookieStand.Description;

      _context.Entry(chosenCS).State = EntityState.Modified;
       _context.SaveChangesAsync();

      return chosenCS;
    }

    [HttpDelete]
    [Route("api/cookiestand/{id}")]
    public async void DeleteCookieStand( string id )
    {
      var chosenCS = _context.CookieStands.Where(cs => cs.Id == id).FirstOrDefault();
      if (chosenCS != null)
      {
        _context.CookieStands.Remove(chosenCS);
        await _context.SaveChangesAsync();
      }
    }
  }
}

