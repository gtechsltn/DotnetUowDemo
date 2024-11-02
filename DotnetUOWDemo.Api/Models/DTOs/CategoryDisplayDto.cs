using System.ComponentModel.DataAnnotations;

namespace DotnetUOWDemo.Api.Models.DTOs;

public class CategoryDisplayDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
