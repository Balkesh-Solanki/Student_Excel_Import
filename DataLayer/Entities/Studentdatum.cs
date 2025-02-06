using System;
using System.Collections.Generic;

namespace Student_Excel_Data_Import_API.DataLayer.Entities;

public partial class Studentdatum
{
    public int Id { get; set; }

    public string? StudentName { get; set; }

    public string? StudentStatus { get; set; }

    public DateOnly? Dob { get; set; }

    public string? CourseType { get; set; }

    public string? CourseName { get; set; }

    public string? Subject { get; set; }

    public int? Duration { get; set; }

    public decimal? StudentHourlyRate { get; set; }

    public decimal? StudentFees { get; set; }

    public string? TutorName { get; set; }

    public decimal? TutorHourlyRate { get; set; }

    public decimal? TutorCharge { get; set; }

    public string? InvoiceNo { get; set; }

    public string? BalanceReference { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public string? Notes { get; set; }
}
