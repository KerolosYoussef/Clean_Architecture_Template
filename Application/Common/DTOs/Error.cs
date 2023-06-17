using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs
{
    public class Error
    {
        public string Code { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Target { get; set; } = null!; 
        public List<Error> Details { get; set; } = null!;
    }
}
