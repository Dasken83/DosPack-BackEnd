using Microsoft.AspNetCore.Mvc;
using DospackFull.Data;
using DospackFull.Models;
using DospackFull.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DospackFull.Controllers
{
    [ApiController]
    [Route("api/dos")]
    public class DosController : ControllerBase
    {
        private readonly DosContext _context;
        private readonly IHubContext<DosHub> _hub;

        public DosController(DosContext context, IHubContext<DosHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDos([FromBody] DosEvent dosEvent)
        {
            dosEvent.Id = Guid.NewGuid();
            dosEvent.Timestamp = DateTime.UtcNow;

            _context.DosEvents.Add(dosEvent);
            await _context.SaveChangesAsync();
            await _hub.Clients.All.SendAsync("DoseUpdate", dosEvent);

            return Ok(dosEvent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _context.DosEvents.ToListAsync();
            return Ok(events);
        }
    }
}
