namespace Injecting.Dependencies.Repository;

public interface IReservationRepository : IRepository<ReservationDAO> {  }

public class ReservationsRepository : IReservationRepository
{
    private readonly RestaurantDbContext _context;

    public ReservationsRepository(RestaurantDbContext context)
    {
        _context = context;
    }

    public void Insert(ReservationDAO item)
    {
        _context.Reservations.Add(item);
    }

    public void Delete(ReservationDAO item)
    {
        _context.Reservations.Remove(item);
    }

    public IEnumerable<ReservationDAO> GetBy(Func<ReservationDAO, bool> predicate)
    {
        return _context.Reservations.Where(predicate);
    }
}