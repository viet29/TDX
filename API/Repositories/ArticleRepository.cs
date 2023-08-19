using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using API.Extensions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace API.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public ArticleRepository(DataContext context, IMapper mapper, UserManager<User> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<ArticleResponse> AddOrUpdateArticle(ArticleRequest articleReq)
        {
            var tmp = await context.Articles.FirstOrDefaultAsync(x => x.Id == articleReq.Id);

            if (tmp == null)
            {
                var article = mapper.Map<Article>(articleReq);

                var roles = await userManager.GetRolesAsync(article.User);
                if(roles.Contains("Admin") || roles.Contains("Manager"))
                {
                    article.IsPublished = true;
                } else
                {
                    article.IsPublished = false;
                }
                
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

        public async Task<IEnumerable<ArticleResponse>> GetAllPublishedArticles()
        {
            return await context.Articles.Where(x => x.IsPublished == true).ProjectTo<ArticleResponse>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<ArticleDetailResponse> GetArticle(int id)
        {
            var article = await context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<ArticleDetailResponse>(article);
        }

        public async Task<bool> ChangeState(int id)
        {
            var article = await context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            article.IsPublished = !article.IsPublished;

            await context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }

}

