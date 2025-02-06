using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace Student_Excel_Data_Import_API.Controllers
{
    [Route("api/excel")]
    [ApiController]
    public class StudentExcelController : ControllerBase
    {
        private readonly IStudentExcelService _studentExcelService;

        public StudentExcelController(IStudentExcelService studentExcelService)
        {
            _studentExcelService = studentExcelService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("Please upload a valid Excel file.");

                var extension = Path.GetExtension(file.FileName);
                if (extension != ".xls" && extension != ".xlsx")
                    return BadRequest("Invalid file format. Only .xls or .xlsx files are allowed.");

                await _studentExcelService.ProcessExcelFile(file);

                return Ok(new { message = "Excel file uploaded and processed successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
