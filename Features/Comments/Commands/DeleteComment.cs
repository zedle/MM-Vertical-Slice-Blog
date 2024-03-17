using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VSBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace VSBlog.Features.Comments.Commands
{
    public record DeleteCommentCommand(int Id) : IRequest<bool>;

    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteCommentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (comment == null)
            {
                return false;
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
