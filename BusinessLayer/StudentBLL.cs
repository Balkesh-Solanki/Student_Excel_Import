using ClosedXML.Excel;
using DTO.ResDTO;
using Microsoft.AspNetCore.Http;
using Student_Excel_Data_Import_API.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentBLL
    {
        private readonly ApplicationDbContext _context;

        public StudentBLL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentExcelResDTO> ProcessExcelFile(IFormFile file)
        {
            var response = new StudentExcelResDTO();

            try
            {
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                using var workbook = new XLWorkbook(stream);
                var worksheet = workbook.Worksheet(1);

                var students = new List<Studentdatum>();

                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    var student = new Studentdatum
                    {
                        StudentName = row.Cell(1).GetString().Trim(),
                        StudentStatus = row.Cell(2).GetString().Trim(),
                        CourseType = row.Cell(4).GetString().Trim(),
                        CourseName = row.Cell(5).GetString().Trim(),
                        Subject = row.Cell(6).GetString().Trim(),
                        Duration = int.TryParse(row.Cell(7).GetString().Trim(), out var duration) ? duration : 0,
                        StudentHourlyRate = decimal.TryParse(row.Cell(8).GetString().Trim(), out var shr) ? shr : 0,
                        StudentFees = decimal.TryParse(row.Cell(9).GetString().Trim(), out var fees) ? fees : 0,
                        TutorName = row.Cell(10).GetString().Trim(),
                        TutorHourlyRate = decimal.TryParse(row.Cell(11).GetString().Trim(), out var thr) ? thr : 0,
                        TutorCharge = decimal.TryParse(row.Cell(12).GetString().Trim(), out var charge) ? charge : 0,
                        InvoiceNo = row.Cell(13).GetString().Trim(),
                        BalanceReference = row.Cell(14).GetString().Trim(),
                        Notes = row.Cell(16).GetString().Trim(),
                    };

                    var dateString = row.Cell(3).GetString().Trim();
                    if (!string.IsNullOrEmpty(dateString) &&
                        DateTime.TryParseExact(dateString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
                    {
                        student.Dob = DateOnly.FromDateTime(parsedDateTime);
                    }
                    else
                    {
                        student.Dob = null;
                    }

                    var paymentDateString = row.Cell(15).GetString().Trim();
                    if (!string.IsNullOrEmpty(paymentDateString) &&
                        DateTime.TryParseExact(paymentDateString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime paymentDateTime))
                    {
                        student.PaymentDate = DateOnly.FromDateTime(paymentDateTime);
                    }
                    else
                    {
                        student.PaymentDate = null;
                    }

                    students.Add(student);
                }

                await _context.Studentdata.AddRangeAsync(students);
                await _context.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Data imported successfully!";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }
    }
}
