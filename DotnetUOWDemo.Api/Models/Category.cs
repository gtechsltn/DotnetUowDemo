using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotnetUOWDemo.Api.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = [];
}
