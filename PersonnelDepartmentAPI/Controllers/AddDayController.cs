using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelDepartmentAPI.Classes;
using PersonnelDepartmentAPI.ClassesDTO;

namespace PersonnelDepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDayController : ControllerBase
    {
        private DepartmentPersonnelContext _context;
        public AddDayController()
        {
            _context = new();
        }

        [HttpPost("AddWorkingDay")]
        public async Task<ActionResult> AddWorkingDay(WorkingDTO working)
        {
            _context.Workings.Add(working.Convert());
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("AddSickDay")]
        public async Task<ActionResult> AddSickDay(SickDTO sick)
        {
            _context.Sicks.Add(sick.Convert());
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("AddOmissionDay")]
        public async Task<ActionResult> AddOmissionDay(OmissionDTO omission)
        {
            _context.Omissions.Add(omission.Convert());
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("AddVacationDay")]
        public async Task<ActionResult> AddVacationDay(VacationDTO vacation)
        {
            _context.Vacations.Add(vacation.Convert());
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
