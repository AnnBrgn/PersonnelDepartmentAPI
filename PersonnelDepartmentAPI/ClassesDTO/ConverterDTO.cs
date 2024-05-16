using Microsoft.Extensions.Hosting;
using PersonnelDepartmentAPI.ClassesDTO;

namespace PersonnelDepartmentAPI.Classes
{
    public static class ConverterDTO
    {
        public static Worker Convert(this WorkerDTO workerDTO)
        {
            if (workerDTO == null)
                return default;

            return new Worker()
            {
                Name = workerDTO.Name,
                LastName = workerDTO.LastName,
                Patronymic = workerDTO.Patronymic,
                Birthday = workerDTO.Birthday,
                Id = workerDTO.Id,
                Gender = workerDTO.Gender,
                Image = workerDTO.Image,
                FamilyStatus = workerDTO.FamilyStatus,
                IdRole = workerDTO.IdRole,
                IdDirector = workerDTO.IdDirector,
                IdPost = workerDTO.IdPost,
            };
        }
        public static WorkerDTO Convert(this Worker worker)
        {
            if (worker == null)
                return default;
            
            return new WorkerDTO() { 
                Id = worker.Id,
                Name = worker.Name,
                LastName = worker.LastName,
                Patronymic = worker.Patronymic,
                Birthday = worker.Birthday,
                Gender = worker.Gender,
                FamilyStatus = worker.FamilyStatus,
                IdRole = worker.IdRole,
                IdDirector = worker.IdDirector,
                IdPost = worker.IdPost
            };
        }
        public static PostDTO Convert(this Post post)
        {
            if (post == null)
                return default;

            return new PostDTO()
            {
                Id = post.Id,
                Title = post.Title,
                Salary = post.Salary
            };
        }
        public static Post Convert(this PostDTO postDTO)
        {
            if (postDTO == null)
                return default;

            return new Post()
            {
                Id = postDTO.Id,
                Title = postDTO.Title,
                Salary = postDTO.Salary
            };
        }
        public static InfoWorker Convert(this InfoWorkerDTO worker)
        {
            if (worker == null)
                return default;

            return new InfoWorker()
            {
                IdWorker = worker.IdWorker,
                SeriesPassport = worker.SeriesPassport,
                NumberPassport = worker.NumberPassport,
                Snils = worker.Snils,
                NumberPhone = worker.NumberPhone,
                Education = worker.Education,
                Inn = worker.Inn
            };
        }
        public static InfoWorkerDTO Convert(this InfoWorker worker)
        {
            if (worker == null)
                return default;

            return new InfoWorkerDTO()
            {
                IdWorker = worker.IdWorker,
                SeriesPassport = worker.SeriesPassport,
                NumberPassport = worker.NumberPassport,
                Snils = worker.Snils,
                NumberPhone = worker.NumberPhone,
                Education = worker.Education,
                Inn = worker.Inn
            };
        }
        public static UserDTO Convert(this User user)
        {
            if (user == null)
                return default;

            return new UserDTO()
            {
                Name = user.Name,
                Login = user.Login,
                Password = user.Password
            };     
        }
        public static Role Convert(this RoleDTO role)
        {
            if (role == null)
                return default;
            return new Role() 
            { 
                Id = role.Id,
                RoleTitle = role.RoleTitle
            };
        }
        public static RoleDTO Convert(this Role role)
        {
            if (role == null)
                return default;

            return new RoleDTO()
            {
                Id = role.Id,
                RoleTitle = role.RoleTitle
            };
        }
        public static Working Convert(this WorkingDTO workingDay)
        {
            if (workingDay == null)
                return default;
            return new Working()
            {
                Date = workingDay.Date,
                IdWorker = workingDay.IdWorker,
                WorkingDay = workingDay.WorkingDay  
            };
        }
        public static WorkingDTO Convert(this Working workingDay)
        {

            if (workingDay == null)
                return default;
            return new WorkingDTO()
            {
                WorkingDay = workingDay.WorkingDay, 
                IdWorker = workingDay.IdWorker,
                Date = workingDay.Date,
            };
        }
        public static Sick Convert(this SickDTO sick)
        {
            if (sick == null)
                return default;
            return new Sick()
            {
                Date = sick.Date,
                IdWorker = sick.IdWorker,
                Description = sick.Description,
                SickDay = sick.SickDay
            };
        }
        public static SickDTO Convert(this Sick sick)
        {
            if (sick == null)
                return default;
            return new SickDTO()
            {
                Date = sick.Date,
                IdWorker = sick.IdWorker,
                Description = sick.Description,
                SickDay = sick.SickDay
            };
        }
        public static Omission Convert(this OmissionDTO omission) 
        {
            if (omission == null)
                return default;
            return new Omission()
            {
                Date = omission.Date,
                IdWorker = omission.IdWorker,
                Description = omission.Description,
                OmissionDay = omission.OmissionDay
            };
        }
        public static OmissionDTO Convert(this Omission omission)
        {
            if (omission == null)
                return default;
            return new OmissionDTO()
            {
                Date = omission.Date,
                IdWorker = omission.IdWorker,
                Description = omission.Description,
                OmissionDay = omission.OmissionDay
            };
        }
        public static Vacation Convert(this VacationDTO vacation)
        {
            if (vacation == null)
                return default;
            return new Vacation()
            {
                Date = vacation.Date,
                IdWorker = vacation.IdWorker,
                VacationDay = vacation.VacationDay
            };
        }
        public static VacationDTO Convert(this Vacation vacation)
        {
            if (vacation == null)
                return default;
            return new VacationDTO()
            {
                Date = vacation.Date,
                IdWorker = vacation.IdWorker,
                VacationDay = vacation.VacationDay
            };
        }
    }
}
