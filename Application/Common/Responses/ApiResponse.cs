using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Responses
{
    public class ApiResponse
    {
        public ApiResponse(int status, dynamic data)
        {
            Status = status;
            Data = data;
        }

        public int Status { get; set; }
        public dynamic Data { get; set; }
    }
}
