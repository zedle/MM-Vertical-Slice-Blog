using MediatR;
using Microsoft.EntityFrameworkCore;
using VSBlog.Data;
using VSBlog.Features.Articles.Models;

namespace VSBlog.Features.Articles.Commands
{
    public record CreateArticleCommand(string Title, string Content) : IRequest<int>;

    public class CreateArticleHandler : IRequestHandler<CreateArticleCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateArticleHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = new Article
            {
                Title = request.Title,
                Content = request.Content
            };

            _context.Articles.Add(article);
            await _context.SaveChangesAsync(cancellationToken);

            return article.Id;
        }
    }
}
