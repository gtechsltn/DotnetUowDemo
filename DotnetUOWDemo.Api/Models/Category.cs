using System.ComponentModel.DataAnnotations;

namespace DotnetUOWDemo.Api.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;
}
