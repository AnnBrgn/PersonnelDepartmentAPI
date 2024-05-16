namespace PersonnelDepartmentAPI.Classes
{
    public class WorkerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? Birthday { get; set; }
        public int? IdPost { get; set; }
        public byte[]? Image { get; set; }
        public string? Gender { get; set; }
        public string? FamilyStatus { get; set; }
        public int? IdRole { get; set; }
        public int? IdDirector { get; set; }
    }
}
