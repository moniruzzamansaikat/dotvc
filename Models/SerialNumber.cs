using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace YourProjectName.Models
{
  public class SerialNumber
  {
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public int? ItemId { get; set; }

    [ForeignKey("ItemId")]
    public Item? Item { get; set; }
  }
}