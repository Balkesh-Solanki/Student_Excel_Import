using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.ResDTO;
using Microsoft.AspNetCore.Http;

namespace ServiceLayer.Interfaces
{
    public interface IStudentExcelService
    {
        Task<StudentExcelResDTO> ProcessExcelFile(IFormFile file);

    }
}
