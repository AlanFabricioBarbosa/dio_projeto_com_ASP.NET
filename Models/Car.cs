using System.ComponentModel.DataAnnotations;

namespace CarStore.Api.Models;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Make { get; set; }

    [Required]
    public required string Model { get; set; }

    public int Year { get; set; }

    public decimal Price { get; set; }

    public string? Color { get; set; }

    public bool IsAvailable { get; set; } = true;
}