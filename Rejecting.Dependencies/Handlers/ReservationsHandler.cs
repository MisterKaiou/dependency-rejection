using Injecting.Dependencies.Domain;
using Injecting.Dependencies.Models;
using Injecting.Dependencies.Services.Mappers;
using Microsoft.AspNetCore.Mvc;
using Rejecting.Dependencies.DatabaseAdapters;
using Rejecting.Dependencies.Mappers;
using Rejecting.Dependencies.Services;

namespace Rejecting.Dependencies.Handlers;

public static class ReservationHandlerBuilder
{
    private static ReservationsHandler? _handler;

    public static WebApplication ConfigureReservationHandler(this WebApplication app)
    {
        _handler = new ReservationsHandler(
            new RestaurantDbContext()
        );

        app.MapPost(
            ReservationsHandler.CREATE,
            ([FromBody] CreateReservationRequest request) => _handler.AddNew(request)
        );

        app.MapGet(
            ReservationsHandler.GET_FOR,
            ([FromQuery] string requesteeName, [FromQuery] DateTime reserveDate) 
                => _handler.GetForRequestee(requesteeName, reserveDate)
        );

        app.MapGet(
            ReservationsHandler.GET_ALL,
            () => _handler.GetAll()
        );
        
        return app;
    }

    private class ReservationsHandler
    {
        private readonly RestaurantDbContext _context;

        private const string _endpointBase = "reservation";
        public const string CREATE = _endpointBase;
        public const string GET_ALL = $"{_endpointBase}/all";
        public const string GET_FOR = _endpointBase;

        public ReservationsHandler(RestaurantDbContext context)
        {
            _context = context;
        }

        public IResult AddNew(CreateReservationRequest request)
        {
            var reserved = ReservationsRepository
                .GetBy(
                    r => r.ReserveDate == request.ReserveDate,
                    _context)
                .Select(r => r.FromDAO());
            var toBook = request.FromRequest();

            var canBookTable = ReservationService.CanBookTable(toBook, reserved);

            if (canBookTable == false)
                return Results.BadRequest(
                    $"A reservation for {request.RequesteeName} already exists for day {request.ReserveDate:d}"
                );

            ReservationsRepository.Insert(toBook.ToDAO(), _context);
            return Results.NoContent();
        }

        public IResult GetForRequestee(string requesteeName, DateTime reserveDate)
        {
            var reserved = ReservationsRepository
                .GetBy(
                    r => r.ReserveDate >= DateTime.Today.Date,
                    _context)
                .Select(r => r.FromDAO());

            var reservation = ReservationService
                .GetReservationForRequestee(requesteeName, reserveDate, reserved);

            if (reservation is null)
                return Results.NotFound();

            return Results.Ok(reservation.ToResponse());
        }

        public IResult GetAll()
        {
            var reserved = ReservationsRepository
                .GetBy(
                    r => r.ReserveDate >= DateTime.Today.Date,
                    _context)
                .Select(r => r
                    .FromDAO()
                    .ToResponse()
                );

            return Results.Ok(reserved);
        }
    }
}