using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VSBlog.Data;
using VSBlog.Features.Articles.Models;

namespace VSBlog.Features.Articles.Queries
{
    public record GetArticleQuery(int Id) : IRequest<Article>;

    public class GetArticleHandler : IRequestHandler<GetArticleQuery, Article>
    {
        private readonly ApplicationDbContext _context;

        public GetArticleHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Article> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (article == null)
            {
                return null; // Or handle not found scenario appropriately
            }

            return article;
        }
    }
}
