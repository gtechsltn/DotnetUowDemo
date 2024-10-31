using System.ComponentModel.DataAnnotations;

namespace DotnetUOWDemo.Api.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string ProductName { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
