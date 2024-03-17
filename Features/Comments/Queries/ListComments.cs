using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VSBlog.Data;
using VSBlog.Features.Comments.Models;

namespace VSBlog.Features.Comments.Queries
{
    public record ListCommentsQuery(int ArticleId, int PageNumber, int PageSize) : IRequest<List<Comment>>;

    public class ListCommentsHandler : IRequestHandler<ListCommentsQuery, List<Comment>>
    {
        private readonly ApplicationDbContext _context;

        public ListCommentsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> Handle(ListCommentsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Comments
                                .Where(c => c.ArticleId == request.ArticleId)
                                .Skip((request.PageNumber - 1) * request.PageSize)
                                .Take(request.PageSize);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
