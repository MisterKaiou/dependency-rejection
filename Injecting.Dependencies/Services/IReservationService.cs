using Injecting.Dependencies.Domain;

namespace Injecting.Dependencies.Services;

public interface IReservationService
{
    bool AddNewReservation(Reservation reservation);

    Reservation? GetReservationForRequesteeOnDate(string requesteeName, DateTime onDate);

    IEnumerable<Reservation> GetAll();
}