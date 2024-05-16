using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonnelDepartmentAPI.Classes;
using System.Text.Json;

namespace PersonnelDepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddWorkerController : ControllerBase
    {
        private DepartmentPersonnelContext dataBase;

        public AddWorkerController()
        {
            dataBase = new();
        }

        [HttpPost("AddWorker")]
        public async Task<ActionResult<WorkerDTO>> AddWorker(WorkerDTO worker)
        {
            if (worker == null)
                return BadRequest();

            var v = worker.Convert();
            if (worker != null)
            {
                dataBase.Workers.Add(v);
                await dataBase.SaveChangesAsync();
            }

            return Ok(v);
        }

        [HttpGet("GetWorkers")]
        public async Task<ActionResult<List<WorkerDTO>>> GetWorkers()
        {
            var workers = dataBase.Workers.Select(s => s.Convert());
            return Ok(await workers.ToListAsync());
        }
        
        [HttpGet("GetWorker")]
        public async Task<ActionResult<List<WorkerDTO>>> GetWorker(int id)
        {
            var worker = await dataBase.Workers.FirstOrDefaultAsync(s => s.Id == id);
            return Ok(worker.Convert());
        }

        [HttpGet("GetImage")]
        public async Task<ActionResult<byte[]>> GetImage(int id)
        {
            var worker = await dataBase.Workers.FirstOrDefaultAsync(s => s.Id == id);
            return Ok(worker.Image);
        }
        [HttpPost("EditWorker")]
        public async Task EditWorker(WorkerDTO worker)
        {
            var work = await dataBase.Workers.FirstOrDefaultAsync(s => s.Id == worker.Id);
            work.Name = worker.Name;
            work.LastName = worker.LastName;
            work.Patronymic = worker.Patronymic;
            work.Gender = worker.Gender;
            work.Birthday = worker.Birthday;
            work.FamilyStatus = worker.FamilyStatus;
            work.Image = worker.Image;
            dataBase.Entry(work).State = EntityState.Modified;
            await dataBase.SaveChangesAsync();
        }
        [HttpPost("EditInfoWorker")]
        public async Task EditInfoWorker(InfoWorkerDTO worker)
        {
            var workInfo = await dataBase.InfoWorkers.FirstOrDefaultAsync(s => s.IdWorker==worker.IdWorker);
            workInfo.NumberPhone = worker.NumberPhone;
            workInfo.NumberPassport = worker.NumberPassport;
            workInfo.Education = worker.Education;
            workInfo.Inn = worker.Inn;
            workInfo.Snils = worker.Snils;
            workInfo.SeriesPassport = worker.SeriesPassport;
            dataBase.Entry(workInfo).State = EntityState.Modified;
            await dataBase.SaveChangesAsync();
        }

        [HttpPost("DeleteWorker")]
        public async Task DeleteWorker(int id)
        {
            var worker = await dataBase.Workers.FirstOrDefaultAsync(s => s.Id == id);
            
            var sicks = dataBase.Sicks.Where(s=>s.IdWorker ==  id);
            foreach (var sick in sicks)
            {
                dataBase.Entry(sick).State = EntityState.Deleted;
            }

            var omissions = dataBase.Omissions.Where(s => s.IdWorker == id);
            foreach (var omission in omissions)
            {
                dataBase.Entry(omission).State = EntityState.Deleted;
            }

            var infoWorkers = dataBase.InfoWorkers.Where(s => s.IdWorker == id);
            foreach (var infoWorker in infoWorkers)
            {
                dataBase.Entry(infoWorker).State = EntityState.Deleted;
            }

            var workings = dataBase.Workings.Where(s => s.IdWorker == id);
            foreach (var working in workings)
            {
                dataBase.Entry(working).State = EntityState.Deleted;
            }
            var vacations = dataBase.Vacations.Where(s => s.IdWorker == id);
            foreach (var vacation in vacations)
            {
                dataBase.Entry(vacation).State = EntityState.Deleted;
            }

            dataBase.Entry(worker).State = EntityState.Deleted;

            await dataBase.SaveChangesAsync();


        }

    }
}
