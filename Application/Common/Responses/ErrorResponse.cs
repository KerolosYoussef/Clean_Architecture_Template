using Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Responses
{
    public class ErrorResponse
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
        public string? Target { get; set; }
        public string? PropertyPath { get; set; } = null!;
        public List<Error> Details { get; set; } = null!;
    }
}
