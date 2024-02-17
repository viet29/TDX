using API.Data;
using API.Entities;
using API.Interfaces;
using API.Extensions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using API.Entities.Responses;
using API.Entities.Requests;

namespace API.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public ArticleRepository(DataContext context, IMapper mapper, UserManager<User> userManager)
        {
            this.dataContext = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<ArticleResponse> AddOrUpdateArticle(ArticleRequest articleReq)
        {
            var tmp = await dataContext.Articles.FirstOrDefaultAsync(x => x.Id == articleReq.Id);

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
                
                await dataContext.Articles.AddAsync(article);
                await dataContext.SaveChangesAsync();
                return mapper.Map<ArticleResponse>(article);
            }

            tmp = mapper.Map<ArticleRequest, Article>(articleReq, tmp);

            dataContext.Articles.Update(tmp);
            await dataContext.SaveChangesAsync();

            return mapper.Map<ArticleResponse>(tmp);


        }



        public async Task<bool> DeleteArticle(int id)
        {
            var tmp = await dataContext.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if (tmp == null)
                return await Task.FromResult(false);

            dataContext.Articles.Remove(tmp);
            await dataContext.SaveChangesAsync();

            return await Task.FromResult(true);
        }


        public async Task<IEnumerable<ArticleResponse>> GetAllArticles()
        {
            return await dataContext.Articles.ProjectTo<ArticleResponse>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<ArticleResponse>> GetAllPublishedArticles()
        {
            return await dataContext.Articles.Where(x => x.IsPublished == true).ProjectTo<ArticleResponse>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<ArticleDetailResponse> GetArticle(int id)
        {
            var article = await dataContext.Articles.Include(a => a.User).FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<ArticleDetailResponse>(article);
        }

        public async Task<bool> ChangeState(int id)
        {
            var article = await dataContext.Articles.FirstOrDefaultAsync(x => x.Id == id);

            article.IsPublished = !article.IsPublished;

            await dataContext.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }

}

