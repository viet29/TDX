using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface IArticleRepository
    {
        Task<ArticleResponse> AddOrUpdateArticle(ArticleRequest articleRequest);

        Task<bool> DeleteArticle(int id);

        Task<IEnumerable<ArticleResponse>> GetAllArticles();

        Task<ArticleResponse> GetArticle(int id);
    }
}
