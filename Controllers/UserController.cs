using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi1.Data;
using webApi1.Entities;

namespace webApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DataContext _context;

        public UserController(DataContext context, ILogger<UserController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            var user = await _context.Users.FindAsync(id );
            if (user == null) { return NotFound(); }
            return user;
        }
    }
}
