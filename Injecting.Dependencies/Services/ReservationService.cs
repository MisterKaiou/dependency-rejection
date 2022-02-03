using Injecting.Dependencies.Domain;
using Injecting.Dependencies.Repository;
using Injecting.Dependencies.Services.Mappers;

namespace Injecting.Dependencies.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _repository;

    public ReservationService(IReservationRepository repository)
    {
        _repository = repository;
    }
    
    public bool AddNewReservation(Reservation reservation)
    {
        var reserve =
            GetReservationForRequesteeOnDate(
                reservation.RequesteeName,
                reservation.ReserveDate);

        if (reserve is not null)
            return false;
        
        _repository.Insert(reservation.ToDAO());
        return true;
    }

    public Reservation? GetReservationForRequesteeOnDate(string requesteeName, DateTime onDate)
    {
        var reserve =
            _repository.GetBy(r => r.RequesteeName == requesteeName && r.ReserveDate == onDate)
                .FirstOrDefault();

        return reserve?.FromDAO();
    }

    public IEnumerable<Reservation> GetAll()
    {
        return _repository
            .GetBy(_ => true)
            .Select(r => r.FromDAO())
            .ToList();
    }
}