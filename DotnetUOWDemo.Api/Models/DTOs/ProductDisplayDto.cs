using System.ComponentModel.DataAnnotations;

namespace DotnetUOWDemo.Api.Models.DTOs;

public class ProductDisplayDto
{
    public int Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;
}
