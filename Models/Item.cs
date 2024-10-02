using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace YourProjectName.Models {
  public class Item {
    public int Id { get; set; }
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public decimal? Discount { get; set; }
    public DateTime? ExpirationDate { get; set; }
  }
}