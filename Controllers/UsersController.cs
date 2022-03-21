using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _context.AppUsers
                .FirstOrDefaultAsync(u => u.Id == id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var users = await _context.AppUsers.ToListAsync();
            return Ok(users);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAllList(string keyword)
        {
            var users = await _context.AppUsers
                .Where(x => x.Username.Contains(keyword))
                .ToListAsync();
            return Ok(users);
        }
    }
}