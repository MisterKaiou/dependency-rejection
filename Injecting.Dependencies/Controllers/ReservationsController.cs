using Injecting.Dependencies.Domain;
using Injecting.Dependencies.Models;
using Injecting.Dependencies.Services;
using Injecting.Dependencies.Services.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Injecting.Dependencies.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _service;

    public ReservationsController(IReservationService service)
    {
        _service = service;
    }

    [HttpGet("all")]
    public IActionResult GetAllReservations()
    {
        return Ok(
            _service
                .GetAll()
                .Select(r => new ReservationModel()
                {
                    Id = r.Id,
                    RequesteeName = r.RequesteeName,
                    ReserveDate = r.ReserveDate,
                    TableNumber = r.TableNumber
                })
            );
    }
    
    [HttpGet]
    public IActionResult GetReservation([FromQuery] string requesteeName, [FromQuery] DateTime reserveDate)
    {
        var reserve = _service.GetReservationForRequesteeOnDate(requesteeName, reserveDate);

        if (reserve is null)
            return NotFound();
        
        return Ok(reserve.ToDAO());
    }

    [HttpPost]
    public IActionResult CreateReservation([FromBody] CreateReservationRequest request)
    {
        var toInsert = 
            Reservation.NewReservation(request.RequesteeName, request.ReserveDate, request.TableNumber);

        var success = _service.AddNewReservation(toInsert);

        if (success)
            return NoContent();

        return BadRequest(
            $"A reservation for {request.RequesteeName} already exists for day {request.ReserveDate:d}"
            );
    }
}