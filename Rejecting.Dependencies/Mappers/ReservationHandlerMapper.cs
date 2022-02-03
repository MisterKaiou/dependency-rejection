using Injecting.Dependencies.Domain;
using Injecting.Dependencies.Models;

namespace Rejecting.Dependencies.Mappers;

public static class ReservationHandlerMapper
{
    public static Reservation FromRequest(this CreateReservationRequest request)
    {
        return Reservation.NewReservation(
            request.RequesteeName,
            request.ReserveDate,
            request.TableNumber
        );
    }

    public static ReservationModel ToResponse(this Reservation reservation)
    {
        return new ReservationModel
        {
            Id = reservation.Id,
            RequesteeName = reservation.RequesteeName,
            ReserveDate = reservation.ReserveDate,
            TableNumber = reservation.TableNumber
        };
    }
}