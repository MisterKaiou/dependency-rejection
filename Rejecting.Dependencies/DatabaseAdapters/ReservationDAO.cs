namespace Rejecting.Dependencies.DatabaseAdapters;

public record class ReservationDAO
{
    public Guid Id { get; set; }
    public string? RequesteeName { get; set; }
    public DateTime ReserveDate { get; set; }
    public byte TableNumber { get; set; }
}