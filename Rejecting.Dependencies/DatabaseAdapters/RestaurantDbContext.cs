namespace Rejecting.Dependencies.DatabaseAdapters;

public class RestaurantDbContext
{
    public static HashSet<ReservationDAO> Reservations { get; } = new();
}