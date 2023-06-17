using Application.Speicifications;
using Application.Users.Queries;
using Contracts.User;
using Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var query = new GetAllUsersQuery();
            var response = await _mediator.Send(query);
            return response.Match(
                    result => Ok(_mapper.Map<List<UserResponse>>(result)),
                    errors => Problem(errors));
        }
    }
}
