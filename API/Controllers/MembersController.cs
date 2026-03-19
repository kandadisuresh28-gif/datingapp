using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IReadOnlyList<AppUser>> GetMembers()
        {
            var members = context.Users.ToList();

            return members;
        }

         [HttpGet("{Id}")]
         public ActionResult<AppUser> GetMember(String Id)
        {
            var memver =context.Users.Find(Id);

            if ( memver==null) return NotFound() ;

            return memver;
        }
    }
}
