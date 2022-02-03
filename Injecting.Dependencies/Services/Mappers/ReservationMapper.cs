using Injecting.Dependencies.Domain;
using Injecting.Dependencies.Repository;

namespace Injecting.Dependencies.Services.Mappers;

public static class ReservationMapper
{
    public static ReservationDAO ToDAO(this Reservation reservation)
    {
        return new ReservationDAO()
        {
            Id = reservation.Id,
            RequesteeName = reservation.RequesteeName,
            ReserveDate = reservation.ReserveDate,
            TableNumber = reservation.TableNumber
        };
    }

    public static Reservation FromDAO(this ReservationDAO reservation)
    {
        return Reservation.NewReservation(
            reservation.RequesteeName, 
            reservation.ReserveDate, 
            reservation.TableNumber
        );
    }
}