using DTO.ReqDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class StudentExcelResDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<StudentExcelReqDTO> Students { get; set; } = new List<StudentExcelReqDTO>();
    }
}
