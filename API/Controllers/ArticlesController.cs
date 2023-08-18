using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Entities;
using API.Repositories;
using API.Interfaces;
using API.DTO;
using Microsoft.AspNetCore.Authorization;
using API.Extensions;

namespace API.Controllers
{
    public class ArticlesController : BaseApiController
    {
        private readonly IArticleRepository articleRepository;
        private readonly IUserRepository userRepository;

        public ArticlesController(IArticleRepository articleRepository, IUserRepository userRepository)
        {
            this.articleRepository = articleRepository;
            this.userRepository = userRepository;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleResponse>>> GetArticles()
        {
            return Ok(await articleRepository.GetAllArticles());
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleResponse>> GetArticle(int id)
        {
            var articleRes = await articleRepository.GetArticle(id);

            if (articleRes == null)
            {
                return NotFound();
            }

            return articleRes;
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ArticleResponse>> PutArticle(int id, ArticleRequest res)
        {
            return await articleRepository.AddOrUpdateArticle(res);
        }

        // POST: api/Articles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ArticleResponse>> PostArticle(ArticleRequest articleRes)
        {
            articleRes.User = await userRepository.GetUserByUsernameAsync(User.GetUsername());
            var req = await articleRepository.AddOrUpdateArticle(articleRes);

            return CreatedAtAction("GetArticle", new { id = req.Id }, req);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await articleRepository.DeleteArticle(id);
            return NoContent();
        }
    }
}
