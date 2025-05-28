using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApi.Models;
using ParkingApi.UseCases;

namespace ParkingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingSessionController : ControllerBase
    {
        private readonly ILogger<ParkingSessionController> _logger;
        private readonly AppDbContext _context;

        public ParkingSessionController(ILogger<ParkingSessionController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingSession>>> GetParkingSessionsAsync(
            int pageNumber = 1, int pageSize = 20)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 20;

            var sessions = await _context.ParkingSessions
                .OrderByDescending(s => s.EntryTime) // or any meaningful order
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(sessions);
        }

        [HttpPost]
        public async Task<ActionResult<ParkingSession>> CreateParkingSessionAsync(string plate, decimal ratePerMinute)
        {
            var parkingSession = new ParkingSession
            {
                Plate = plate,
                RatePerMinute = ratePerMinute,
                EntryTime = DateTimeOffset.UtcNow,
            };

            _context.ParkingSessions.Add(parkingSession);
            await _context.SaveChangesAsync();

            return Ok(parkingSession);
        }

        [HttpPatch]
        public async Task<ActionResult<ParkingSession>> FinishParkingSession(int parkingSessionId)
        {
            var parkingSession = await _context.ParkingSessions.FindAsync(parkingSessionId);

            if (parkingSession == null)
            {
                return NotFound();
            }

            parkingSession.FinishParking(DateTimeOffset.UtcNow);
            await _context.SaveChangesAsync();

            return Ok(parkingSession);
        }
    }
}
