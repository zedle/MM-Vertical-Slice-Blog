using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSBlog.Features.Articles.Commands;
using VSBlog.Features.Articles.Queries;
using VSBlog.Features.Articles.Models;

namespace VSBlog.Features.Articles
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateArticle(CreateArticleCommand command)
        {
            var articleId = await _mediator.Send(command);
            return Ok(articleId);
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> ListArticles(int page = 1, int pageSize = 10)
        {
            var articles = await _mediator.Send(new ListArticlesQuery(page, pageSize));
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticleById(int id)
        {
            var article = await _mediator.Send(new GetArticleQuery(id));
            return Ok(article);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticle(int id, UpdateArticleCommand command)
        {
            if (await _mediator.Send(command with { Id = id }))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            if (await _mediator.Send(new DeleteArticleCommand(id)))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
