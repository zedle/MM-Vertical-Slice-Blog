using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VSBlog.Data;
using VSBlog.Features.Comments.Models;

namespace VSBlog.Features.Comments.Commands
{
    public record AddCommentCommand(int ArticleId, string Author, string Content) : IRequest<int>;

    public class AddCommentHandler : IRequestHandler<AddCommentCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public AddCommentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                ArticleId = request.ArticleId,
                Author = request.Author,
                Content = request.Content
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync(cancellationToken);

            return comment.Id;
        }
    }
}
