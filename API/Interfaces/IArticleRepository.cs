using API.Entities;
using API.Entities.Requests;
using API.Entities.Responses;

namespace API.Interfaces
{
    public interface IArticleRepository
    {
        Task<ArticleResponse> AddOrUpdateArticle(ArticleRequest articleRequest);

        Task<bool> DeleteArticle(int id);

        Task<IEnumerable<ArticleResponse>> GetAllArticles();

        Task<IEnumerable<ArticleResponse>> GetAllPublishedArticles();

        Task<ArticleDetailResponse> GetArticle(int id);

        Task<bool> ChangeState(int id);
    }
}
