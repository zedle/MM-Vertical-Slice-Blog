using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VSBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace VSBlog.Features.Articles.Commands
{
    public record UpdateArticleCommand(int Id, string Title, string Content) : IRequest<bool>;

    public class UpdateArticleHandler : IRequestHandler<UpdateArticleCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public UpdateArticleHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (article == null)
            {
                return false;
            }

            article.Title = request.Title;
            article.Content = request.Content;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
