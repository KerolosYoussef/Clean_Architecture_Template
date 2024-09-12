using Application.Common;
using Application.Common.DTOs;
using Application.Permissions.Commands.CreatePermission;
using Application.Permissions.Commands.DeletePermission;
using Application.Permissions.Commands.EditPermission;
using Application.Permissions.Queries.GetAllPermissions;
using Application.Permissions.Queries.GetRolePermissions;
using Application.Permissions.Queries.GetSinglePermission;
using Application.Speicifications;
using Contracts.Permission;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PermissionsController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PermissionsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissionsAsync([FromQuery]GetPermissionsRequest getPermissionsRequest)
        {
            var query = _mapper.Map<GetAllPermissionsQuery>(getPermissionsRequest);
            var response = await _mediator.Send(query);

            return response.Match(
                result =>
                {
                    var permissionResponse = result.Data.Adapt<List<PermissionResponse>>();
                    var paginatedResponse = new Pagination<PermissionResponse>(result.PageIndex, result.PageSize, result.Count, permissionResponse);
                    return Ok(paginatedResponse);
                },
                Problem
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionByIdAsync(Guid id)
        {
            // Initialize single permission specification
            var getSinglePermissionSpec = PermissionSpecifications.GetPermissionByIdSpec(id);

            // create new query with this specification
            var query = new GetSinglePermissionQuery(getSinglePermissionSpec);

            // apply query handler
            var response = await _mediator.Send(query);

            // return response
            return response.Match(
                result => Ok(result.Adapt<PermissionResponse>()),
                Problem
            );
        }

        [HttpGet("role/{id}")]
        public async Task<IActionResult> GetPermissionsByRoleIdAsync(string id)
        {
            // create new query with this specification
            var query = new GetRolePermissionsQuery(id);

            // apply query handler
            var response = await _mediator.Send(query);

            // return response
            return response.Match(
                result => Ok(result.Adapt<PermissionsDto>()),
                Problem
            );
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermissionAsync(CreatePermissionRequest createPermissionRequest)
        {
            // create command
            var command = _mapper.Map<CreatePermissionCommand>(createPermissionRequest);
            // apply command handler
            var response = await _mediator.Send(command);

            return response.Match(
                result => Ok(result.Adapt<PermissionResponse>()),
                Problem
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditPermissionAsync(Guid id, CreatePermissionRequest editPermissionRequest)
        {
            // create command
            var command = _mapper.Map<EditPermissionCommand>(editPermissionRequest);
            command.Id = id;

            // apply command handler
            var response = await _mediator.Send(command);

            return response.Match(
                result => Ok(result.Adapt<PermissionResponse>()),
                Problem
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionAsync(Guid id)
        {
            // create command
            var command = new DeletePermissionCommand(id);

            // apply command handler
            var response = await _mediator.Send(command);

            return response.Match(
                result => Ok(result),
                Problem
            );
        }
    }
}
