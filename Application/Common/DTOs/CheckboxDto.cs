using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs
{
    public record CheckboxDto
    {
        public CheckboxDto(string name, bool isSelected = false)
        {
            Name = name;
            IsSelected = isSelected;
        }

        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
