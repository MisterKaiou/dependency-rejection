namespace Rejecting.Dependencies.DatabaseAdapters;

// The repository stays basically the same, the difference is that it no longer has any state in it.
// It only runs operations on whatever state (context) you provide explicitly every time.
public static class ReservationsRepository
{
    public static void Insert(ReservationDAO item, RestaurantDbContext context)
    {
        RestaurantDbContext.Reservations.Add(item);
    }

    public static void Delete(ReservationDAO item, RestaurantDbContext context)
    {
        RestaurantDbContext.Reservations.Remove(item);
    }

    public static IEnumerable<ReservationDAO> GetBy(Func<ReservationDAO, bool> predicate, RestaurantDbContext context)
    {
        return RestaurantDbContext.Reservations.Where(predicate);
    }
}