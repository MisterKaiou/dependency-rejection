namespace Injecting.Dependencies.Repository;

public class RestaurantDbContext
{
    private static readonly HashSet<ReservationDAO> _reservations = new();

    public HashSet<ReservationDAO> Reservations => _reservations;
}