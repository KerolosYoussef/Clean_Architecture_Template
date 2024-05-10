using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands.EditPermission
{
    public class EditPermissionCommandValidator : AbstractValidator<EditPermissionCommand>
    {
        public EditPermissionCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Module).NotEmpty();
        }
    }
}
