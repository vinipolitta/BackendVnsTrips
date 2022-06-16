using Microsoft.AspNetCore.Mvc;
using VnsTrips.Dtos;

namespace VnsTrips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly DataContext _context;

        public MarketController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Market>>> Get(int userId)
        {
            var markets = await _context.Markets.Where(m => m.UserId == userId).ToListAsync();
            return Ok(markets);
        }

        [HttpPost]
        public async Task<ActionResult<List<Market>>> Create(CreateMarketDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null) return NotFound();

            var newMarket = new Market
            {
                Name = request.Name,
                Category = request.Category,
                DeliveryEstimate = request.DeliveryEstimate,
                Rating = request.Rating,
                ImagePath = request.ImagePath,
                About = request.About,
                Hours = request.Hours,
                User = user

            };
            _context.Markets.Add(newMarket);
            await _context.SaveChangesAsync();

            return await Get(request.UserId);
        }
    }
}
