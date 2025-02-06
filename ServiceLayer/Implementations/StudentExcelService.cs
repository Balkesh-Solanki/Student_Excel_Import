using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using ServiceLayer.Interfaces;
using Student_Excel_Data_Import_API.DataLayer.Entities;
using BusinessLayer;

//using Student_Excel_Data_Import_API.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.ReqDTO;
using DTO.ResDTO;

namespace ServiceLayer.Implementations
{
    public class StudentExcelService : IStudentExcelService
    {
        private readonly StudentBLL _studentBLL;

        public StudentExcelService(StudentBLL studentBLL)
        {
            _studentBLL = studentBLL;
        }

        public async Task<StudentExcelResDTO> ProcessExcelFile(IFormFile file)
        {
            return await _studentBLL.ProcessExcelFile(file);
        }
    }
}
