using MediatR;
using Microsoft.EntityFrameworkCore;
using VSBlog.Data;
using VSBlog.Features.Articles.Models;

namespace VSBlog.Features.Articles.Queries
{
    public record ListArticlesQuery(int PageNumber, int PageSize) : IRequest<List<Article>>;
    public class ListArticlesHandler : IRequestHandler<ListArticlesQuery, List<Article>>
    {
        private readonly ApplicationDbContext _context;

        public ListArticlesHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> Handle(ListArticlesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Articles
                                .Skip((request.PageNumber - 1) * request.PageSize)
                                .Take(request.PageSize);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
