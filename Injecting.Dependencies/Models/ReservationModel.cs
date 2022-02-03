namespace Injecting.Dependencies.Models;

public class ReservationModel
{
    public Guid Id { get; set; }
    public string? RequesteeName { get; set; }
    public DateTime ReserveDate { get; set; }
    public byte TableNumber { get; set; }
}