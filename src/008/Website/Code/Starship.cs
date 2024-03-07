// From 
// https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/input-components?view=aspnetcore-8.0#example-form
using System.ComponentModel.DataAnnotations;

namespace WebApp.BlazorSample;

public class Holodeck
{
    public string? Id { get; set; }
    public bool Booked { get; set; }
}


public class StarshipClass : Starship
{
    [Required]
    [MinLength(2, ErrorMessage = "Select at least two classifications.")]
    [MaxLength(3, ErrorMessage = "Select no more than three classifications.")]
    public Classification[]? SelectedClassification { get; set; } =
        new Classification[] { BlazorSample.Classification.None };
}

public enum Classification { None, Exploration, Diplomacy, Defense, Research }

public class Starship
{
    [Required]
    [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
    public string? Id { get; set; }

    public string? Description { get; set; }

    public string? ProductionClass { get; set; } = "Ianar";

    [Required]
    public string? Classification { get; set; }

    [Range(1, 100000, ErrorMessage = "Accommodation invalid (1-100000).")]
    public int MaximumAccommodation { get; set; }

    [Required]
    [Range(typeof(bool), "true", "true", ErrorMessage = "Approval required.")]
    public bool IsValidatedDesign { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }
}