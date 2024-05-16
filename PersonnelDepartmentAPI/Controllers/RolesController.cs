using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonnelDepartmentAPI.Classes;
using System.Text.Json;

namespace PersonnelDepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private DepartmentPersonnelContext dataBase;

        public RolesController()
        {
            dataBase = new();
        }

        [HttpGet("GetRoles")]
        public async Task<ActionResult<List<RoleDTO>>> GetRoles()
        {
            return Ok(await dataBase.Roles.Select(s=>s.Convert()).ToListAsync());
        }

        [HttpGet("GetRole")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            var role = await dataBase.Roles.FirstOrDefaultAsync(s => s.Id == id);
            return Ok(role.Convert());
        }
    }
}
