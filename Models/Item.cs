using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace YourProjectName.Models
{
  public class Item
  {
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
    public string? Description { get; set; }
    public decimal? Discount { get; set; }
    public DateTime? ExpirationDate { get; set; }

    public int? SerialNumberId { get; set; }
    public SerialNumber? SerialNumber { get; set; }
    public int? CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
  }
}