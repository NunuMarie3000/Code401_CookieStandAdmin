namespace CookieStandAPI.Models
{
  public class CookieStand
  {
    public CookieStand()
    {
      Id = Guid.NewGuid().ToString();
    }
    public string Id { get; private set; }
    public string Location { get; set; }
    public string? Description { get; set; }
    public int Minimum_Customers_Per_Hour { get; set; }
    public int Maximum_Customers_Per_Hour { get; set; }
    public decimal Average_Cookies_Per_Sale { get; set; }
    public string? Owner { get; set; }
  }
}
