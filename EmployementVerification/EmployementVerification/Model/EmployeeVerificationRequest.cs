namespace EmployementVerification.Model
{
    public class EmployeeVerificationRequest
    {
        public int EmployeeId { get; set; }
        public string? CompanyName { get; set; }
        public string? VerificationCode { get; set; }
    }
}
