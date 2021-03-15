using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Server.Commands.AddLookups;
using Server.Commands.EditLookups;
using Server.CQS.Commands;
using Server.CQS.DTOs;
using Server.CQS.Queries;
using Server.Queries.GetLookups;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class ColonyController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost, Route("AddColony")]
        public async Task<IActionResult> AddColony(ColonyDto dto)
        {
            var result = await Mediator.Send(new AddColonyCommand()
            {
                ColonyDto = dto
            });
            return Ok(result);
        }

        [HttpPost, Route("EditColony")]
        public async Task<IActionResult> EditColonyCommand(ColonyDto dto)
        {
            var result = await Mediator.Send(new AddColonyCommand()
            {
                ColonyDto = dto
            });
            if (result == Guid.Empty) return NotFound();
            return Ok(result);
        }

        [HttpGet, Route("GetColonies")]
        public async Task<IActionResult> GetColonies()
        {
            var result = await Mediator.Send(new GetColoniesQuery());
            return Ok(result);
        }

        [HttpPost, Route("AddHost")]
        public async Task<IActionResult> AddHost(string name)
        {
            var result = await Mediator.Send(new AddHostCommand()
            {
                Name = name
            });
            return Ok(result);
        }

        [HttpGet, Route("GetHosts")]
        public async Task<IActionResult> GetHosts()
        {
            var result = await Mediator.Send(new GetHostsQuery());
            return Ok(result);
        }

        [HttpPost, Route("EditHost")]
        public async Task<IActionResult> EditHost(Guid id, string name)
        {
            var result = await Mediator.Send(new EditHostCommand()
            {
                Id = id,
                Name = name
            });

            if (result == Guid.Empty) return NotFound();
            return Ok(result);
        }

        [HttpPost, Route("AddArea")]
        public async Task<IActionResult> AddArea(string name)
        {
            var result = await Mediator.Send(new AddAreaCommand()
            {
                Name = name
            });
            return Ok(result);
        }

        [HttpGet, Route("GetAreas")]
        public async Task<IActionResult> GetAreas()
        {
            var result = await Mediator.Send(new GetAreasQuery());
            return Ok(result);
        }

        [HttpPost, Route("EditArea")]
        public async Task<IActionResult> EditArea(Guid id,string name)
        {
            var result = await Mediator.Send(new EditAreaCommand()
            {
                Id = id,
                Name = name
            });

            if (result == Guid.Empty) return NotFound();
            return Ok(result);
        }



    }
}
