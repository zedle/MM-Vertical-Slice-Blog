using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VSBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace VSBlog.Features.Articles.Commands
{
    public record DeleteArticleCommand(int Id) : IRequest<bool>;

    public class DeleteArticleHandler : IRequestHandler<DeleteArticleCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteArticleHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (article == null)
            {
                return false;
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
