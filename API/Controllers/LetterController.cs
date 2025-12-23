using System.Security.Claims;
using API.Common;
using Application.Commands;
using Application.DTOs;
using Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]

    [Route("[controller]")]
    public class LetterController : AppBaseController
    {
        [HttpPost("send")]
        public async Task<IActionResult> SendLetter([FromForm] SendLetterCommand request, CancellationToken cancellationToken)
        {
            var result = await MediatorSender.Send(request, cancellationToken);
            return Ok(new { LetterId = result });
        }
        [HttpPost("forward")]
        public async Task<IActionResult> ForwardLetter([FromForm] ForwardLetterCommand request, CancellationToken cancellationToken)
        {
            var result = await MediatorSender.Send(request, cancellationToken);
            return Ok(new { LetterId = result });
        }
        [HttpPost("reply")]
        public async Task<IActionResult> ReplyLetter([FromForm] ReplyLetterCommand request, CancellationToken cancellationToken)
        {
            var result = await MediatorSender.Send(request, cancellationToken);
            return Ok(new { LetterId = result });
        }

        [HttpPatch("mark-as-read")]
        public async Task<IActionResult> MarkAsRead(int letterId, CancellationToken cancellationToken)
        {
            await MediatorSender.Send(new MarkAsReadCommand(letterId), cancellationToken);
            return NoContent();
        }
        [HttpGet("inbox")]
        public async Task<ActionResult<List<InboxDto>>> GetInbox([FromQuery] GetInboxQuery request, CancellationToken cancellationToken)
        {
            var result = await MediatorSender.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("outbox")]
        public async Task<ActionResult<List<OutboxDto>>> GetOutbox([FromQuery] GetOutboxQuery request, CancellationToken cancellationToken)
        {
            var result = await MediatorSender.Send(request, cancellationToken);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LetterDto>> GetLetterById(int id, CancellationToken cancellationToken)
        {
            var result = await MediatorSender.Send(new GetLetterByIdQuery(id), cancellationToken);
            return Ok(result);
        }
    }
}
