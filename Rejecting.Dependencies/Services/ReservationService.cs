using Injecting.Dependencies.Domain;

namespace Rejecting.Dependencies.Services;

public static class ReservationService
{
    public static bool CanBookTable(Reservation reservation, IEnumerable<Reservation> alreadyReserved)
    {
        // Here goes the code where you would check whether a table can be booked, checking for any constraints that would
        // have you not book it.
        return !alreadyReserved.Any(r => 
            r.TableNumber == reservation.TableNumber &&
            r.RequesteeName == reservation.RequesteeName);
    }

    public static Reservation? GetReservationForRequestee(string requestee, DateTime reserveDate, IEnumerable<Reservation> reservations)
    {
        return reservations.FirstOrDefault(r => 
            r.RequesteeName == requestee &&
            r.ReserveDate == reserveDate);
    }
}