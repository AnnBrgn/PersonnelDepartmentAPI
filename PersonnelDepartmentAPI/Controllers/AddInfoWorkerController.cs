using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonnelDepartmentAPI.Classes;
using PersonnelDepartmentAPI.ClassesDTO;

namespace PersonnelDepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddInfoWorkerController : ControllerBase
    {
        private DepartmentPersonnelContext dataBase;

        public AddInfoWorkerController() 
        { 
            dataBase = new();
        }
        [HttpPost("AddWorkerInfo")]
        public async Task<ActionResult<InfoWorkerDTO>> AddWorkerInfo(InfoWorkerDTO infoWorkerDTO)
        {
            var v = infoWorkerDTO.Convert();
            dataBase.InfoWorkers.Add(v);
            await dataBase.SaveChangesAsync();
            Console.WriteLine(v.IdWorker + v.NumberPhone);
            return Ok(v.Convert());
        }
        [HttpGet("GetWorkerInfo")]
        public async Task<ActionResult<InfoWorker>> GetWorkerInfo(int id)
        {
            var workerInfo = await dataBase.InfoWorkers.FirstOrDefaultAsync(s => s.IdWorker == id);
            if(workerInfo == null) 
            {
                return NotFound();
            }
            return Ok(await dataBase.InfoWorkers.FirstOrDefaultAsync(s=>s.IdWorker == id));
        }

        [HttpPost("GetMatchingWorker")]
        public async Task<ActionResult<WorkerMatchingResultDTO>> GetWorkerMatching(WorkerDateMatchingDTO matching)
        {
            Working working = await dataBase.Workings.FirstOrDefaultAsync(s => s.Date == matching.Date && s.IdWorker == matching.IdWorker);
            if (working != null)
                return Ok(new WorkerMatchingResultDTO
                {
                    DayType = 0
                });
            Vacation vacation = await dataBase.Vacations.FirstOrDefaultAsync(s => s.Date == matching.Date && s.IdWorker == matching.IdWorker); 
            if(working != null)
                return Ok(new WorkerMatchingResultDTO
                {
                    DayType = 1
                });
            Sick sick = await dataBase.Sicks.FirstOrDefaultAsync(s => s.Date == matching.Date && s.IdWorker == matching.IdWorker);
            if (sick != null)
                return Ok(new WorkerMatchingResultDTO
                {
                    DayType = 2,
                    Description = sick.Description
                });

            Omission omission = await dataBase.Omissions.FirstOrDefaultAsync(s => s.Date == matching.Date && s.IdWorker == matching.IdWorker); 
            if (omission != null)
                return Ok(new WorkerMatchingResultDTO
                {
                    DayType = 3,
                    Description = omission.Description
                });
            return NotFound();
        }
    }
}
