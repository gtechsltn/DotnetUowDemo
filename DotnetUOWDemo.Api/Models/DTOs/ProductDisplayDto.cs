using System.ComponentModel.DataAnnotations;

namespace DotnetUOWDemo.Api.Models.DTOs;

public class ProductDisplayDto
{
    [Required]
    [MaxLength(30)]
    public string ProductName { get; set; } = string.Empty;

    public int CategoryId { get; set; }
}
