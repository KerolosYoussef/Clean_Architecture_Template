using Domain.ModuleAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.GetAllModules
{
    public record GetAllModulesQuery() : IRequest<ErrorOr<IList<Module>>>;
}
