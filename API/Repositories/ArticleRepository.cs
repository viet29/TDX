using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using API.Extensions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ArticleRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ArticleResponse> AddOrUpdateArticle(ArticleRequest articleReq)
        {
            var tmp = await context.Articles.FirstOrDefaultAsync(x => x.Id == articleReq.Id);

            if (tmp == null)
            {
                var article = mapper.Map<Article>(articleReq);

                await context.Articles.AddAsync(article);
                await context.SaveChangesAsync();
                return mapper.Map<ArticleResponse>(article);
            }

            tmp = mapper.Map<ArticleRequest, Article>(articleReq, tmp);

            context.Articles.Update(tmp);
            await context.SaveChangesAsync();

            return mapper.Map<ArticleResponse>(tmp);


        }

        public async Task<bool> DeleteArticle(int id)
        {
            var tmp = await context.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if (tmp == null)
                return await Task.FromResult(false);

            context.Articles.Remove(tmp);
            await context.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<ArticleResponse>> GetAllArticles()
        {
            return await context.Articles.ProjectTo<ArticleResponse>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<ArticleResponse> GetArticle(int id)
        {
            var article = await context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<ArticleResponse>(article);
        }
    }

}

