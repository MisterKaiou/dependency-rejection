namespace Injecting.Dependencies.Models;

public class CreateReservationRequest
{
    public string? RequesteeName { get; set; }
    public DateTime ReserveDate { get; set; }
    public byte TableNumber { get; set; }
}