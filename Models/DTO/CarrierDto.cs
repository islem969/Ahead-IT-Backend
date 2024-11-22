namespace Register.Models.DTO
{
    public class CarrierDto
    {
        public int Salary { get; set; }
        public int Bban { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int RIB { get; set; }
        public int? UserId { get; set; }
        public int? QualificationId { get; set; }
        public int? Civil_StatusId { get; set; }
    }
}
