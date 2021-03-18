using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Server.CQS.Commands;
using Server.CQS.Queries;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class UserController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost, Route("AddUser")]
        public async Task<IActionResult> AddUser(Guid id, string name)
        {
            var result = await Mediator.Send(new AddUserCommand()
            {
                Id = id,
                Name = name
            });
            return Ok(result);
        }

        [HttpPost, Route("EditUser")]
        public async Task<IActionResult> EditUser(Guid id, string name)
        {
            var result = await Mediator.Send(new EditUserCommand()
            {
                Id = id,
                Name = name
            });
            if (result == Guid.Empty) return NotFound();
            return Ok(result);
        }

        [HttpGet, Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await Mediator.Send(new GetUsersQuery());
            return Ok(result);
        }
    }
}
