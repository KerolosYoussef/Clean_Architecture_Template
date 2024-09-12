using Application.Common.Interfaces.Presistance;
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
    public class GetAllModulesQueryHandler : IRequestHandler<GetAllModulesQuery, ErrorOr<IList<Module>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllModulesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<IList<Module>>> Handle(GetAllModulesQuery request, CancellationToken cancellationToken)
        {
            // Get all modules from database
            var modules = await _unitOfWork.Repository<Module>().ListAllAsync();

            return modules.ToList();
        }
    }
}
