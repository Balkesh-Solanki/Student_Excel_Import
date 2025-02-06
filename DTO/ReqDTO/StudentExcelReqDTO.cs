using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class StudentExcelReqDTO
    {
        public string StudentName { get; set; }
        public string StudentStatus { get; set; }
        public DateOnly DOB { get; set; }
        public string CourseType { get; set; }
        public string CourseName { get; set; }
        public string Subject { get; set; }
        public int Duration { get; set; }
        public decimal StudentHourlyRate { get; set; }
        public decimal StudentFees { get; set; }
        public string TutorName { get; set; }
        public decimal TutorHourlyRate { get; set; }
        public decimal TutorCharge { get; set; }
        public string InvoiceNo { get; set; }
        public string BalanceReference { get; set; }
        public DateOnly PaymentDate { get; set; }
        public string Notes { get; set; }
    }
}
