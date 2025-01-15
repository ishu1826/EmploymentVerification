using EmployementVerification.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployementVerification.Controllers
{
    [Route("api/verify-employment")]
    [ApiController]
    public class EmployeeVerificationController : ControllerBase
    {
        private static readonly List<Employee> Employees = new()
    {
        new Employee { EmployeeId = 101, CompanyName = "Ishank Corp", VerificationCode = "Emp1234" },
        new Employee { EmployeeId = 102, CompanyName = "Verma Corp", VerificationCode = "Emp12345678" }
    };
        [HttpPost]
        public IActionResult VerifyEmployment([FromBody] EmployeeVerificationRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.CompanyName) || string.IsNullOrWhiteSpace(request.VerificationCode))
            {
                return BadRequest(new { message = "Invalid input data" });
            }

            var employee = Employees.FirstOrDefault(e =>
                e.EmployeeId == request.EmployeeId &&
                e.CompanyName.Equals(request.CompanyName, StringComparison.OrdinalIgnoreCase) &&
                e.VerificationCode == request.VerificationCode);

            if (employee != null)
            {
                return Ok(new { status = "Verified" });
            }
            else
            {
                return NotFound(new { status = "Not Verified" });

            }
        }
    }
}
