using System.ComponentModel.DataAnnotations;

namespace Trip.API.Models;

public enum ServiceType
{
    Car,
    Bike
}

public class TripModel
{
    public Guid Id { get; init; }

    [Required] public string UserId { get; init; } = default!;

    [Required] public string DriverId { get; init; } = default!;

    [Required] public string Destination { get; set; } = default!;

    [Required] public string PickupLocation { get; init; } = default!;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; init; } = default!;

    [Required] public decimal Price { get; set; } = default!;

    [Required] public ServiceType ServiceType { get; init; } = default!;
}