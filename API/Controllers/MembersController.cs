using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();

            return members;
        }

         [HttpGet("{Id}")]
         //test
         public async Task<ActionResult<AppUser>> GetMember(String Id)
        {
            var memver = await context.Users.FindAsync(Id);

            if ( memver==null) return NotFound() ;

            return memver;
        }
    }
}
