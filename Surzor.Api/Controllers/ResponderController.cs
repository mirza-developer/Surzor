using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Surzor.Application.Features.Responders.Commands;
using Surzor.Application.Features.Responders.Queries;

namespace Surzor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResponderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AllResponderListVm>>> GetAllResponders(CancellationToken token) =>
            Ok(await _mediator.Send(new GetAllResponderListQuery()));

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateResponderCommandResponse>> CreateResponder([FromBody] CreateResponderCommand command, CancellationToken token)
     => Ok((await _mediator.Send(command, token)));

        [HttpGet("[action]")]
        public async Task<FileResult> ExportResponders()
        {
            var file = await _mediator.Send(new GetResponderExportQuery());
            return File(file.Data, file.FileType, file.FileName);
        }
    }
}
