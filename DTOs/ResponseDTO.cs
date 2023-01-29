namespace EFCoreRelationships.DTOs
{
    public class ResponseDTO
    {
        public string? Name { get; set; }
        public string? Department { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        public int Salary { get; set; } = 1450;
    }
}
