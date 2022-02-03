namespace Injecting.Dependencies.Domain;

public class Reservation
{
    public Guid Id { get; set; }
    public Name RequesteeName { get; set; }
    public FutureDate ReserveDate { get; set; }
    public TableNumber TableNumber { get; set; }
    
    private Reservation() { }

    public static Reservation NewReservation(string requesteeName, DateTime reserveDate, byte tableNumber)
    {
        return new Reservation()
        {
            Id = Guid.NewGuid(),
            RequesteeName = requesteeName,
            ReserveDate = reserveDate,
            TableNumber = tableNumber
        };
    }
}