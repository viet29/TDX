using Microsoft.AspNetCore.Mvc;
using API.Entities.Responses;
using API.Entities.Requests;
using API.Interfaces;
using API.Extensions;

namespace API.Controllers
{
    public class FaqsController : BaseApiController
    {
        private readonly IFaqRepository faqRepository;
        private readonly IUserRepository userRepository;

        public FaqsController(IFaqRepository faqRepository, IUserRepository userRepository)
        {
            this.faqRepository = faqRepository;
            this.userRepository = userRepository;
        }

        // GET: api/Faqs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaqResponse>>> GetAllFaqs()
        {
            try
            {
                var faqs = await faqRepository.GetAllFaqAsync();
                return Ok(faqs);
            } catch (Exception)
            {
                return BadRequest("Không thể lấy dữ liệu, vui lòng thư lại sau!");
            }
            
        }

        // GET: api/Faqs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FaqResponse>> GetFaq(int id)
        {
            var faq = await faqRepository.GetFaqAsync(id);

            if (faq == null)
            {
                return NotFound();
            }

            return Ok(faq);
        }

        // PUT: api/Faqs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaq(FaqRequest faq)
        {

            if (!await faqRepository.UpdateFaqAsync(faq))
                return BadRequest("Thay đổi thất bại!");
            return NoContent();
        }

        // POST: api/Faqs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FaqResponse>> AddFaq(FaqRequest faq)
        {
            faq.User = await userRepository.GetUserByUsernameAsync(User.GetUsername());
            var response = await faqRepository.AddFaqAsync(faq);

            return CreatedAtAction("GetFaq", new { id = response.Id }, response);
        }

        // DELETE: api/Faqs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaq(int id)
        {
            if (!await faqRepository.DeleteFaqAsync(id))
                return BadRequest();

            return NoContent();
        }
    }
}
