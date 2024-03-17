using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSBlog.Features.Comments.Commands;
using VSBlog.Features.Comments.Queries;
using VSBlog.Features.Comments.Models;

namespace VSBlog.Features.Comments
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddComment(AddCommentCommand command)
        {
            var commentId = await _mediator.Send(command);
            return Ok(commentId);
        }

        [HttpGet("{articleId}")]
        public async Task<ActionResult<List<Comment>>> ListComments(int articleId, int page = 1, int pageSize = 10)
        {
            var comments = await _mediator.Send(new ListCommentsQuery(articleId, page, pageSize));
            return Ok(comments);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            if (await _mediator.Send(new DeleteCommentCommand(id)))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
