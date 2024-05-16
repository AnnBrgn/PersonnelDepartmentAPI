using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PersonnelDepartmentAPI.Classes;

namespace PersonnelDepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DepartmentPersonnelContext dataBase;

        public AuthController() 
        {
            dataBase = new();
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO login)
        {
            var user = await dataBase.Users.FirstOrDefaultAsync(a => a.Login == login.Login && a.Password == login.Password);
            if (user == null)
            {
                return NoContent();
            }
            return Ok(user.Convert());
        }
    }
}
