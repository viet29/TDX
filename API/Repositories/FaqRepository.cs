using API.Data;
using API.Entities;
using API.Entities.Requests;
using API.Entities.Responses;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class FaqRepository : IFaqRepository
    {

        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public FaqRepository(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<FaqResponse> AddFaqAsync(FaqRequest request)
        {
            var faq = mapper.Map<Faq>(request);

            await dataContext.Faqs.AddAsync(faq);
            await dataContext.SaveChangesAsync();

            return mapper.Map<FaqResponse>(faq);
        }

        public async Task<bool> DeleteFaqAsync(int id)
        {
            var faq = await dataContext.Faqs.FirstOrDefaultAsync(x =>  x.Id == id);

            if (faq == null) 
                return await Task.FromResult(false);

            dataContext.Faqs.Remove(faq);
            await dataContext.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<FaqResponse>> GetAllFaqAsync()
        {
            return await dataContext.Faqs.ProjectTo<FaqResponse>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<FaqResponse> GetFaqAsync(int id)
        {
            var faq = await dataContext.Faqs.FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<FaqResponse>(faq);
        }

        public async Task<bool> UpdateFaqAsync(FaqRequest faqRequest)
        {
            var faq = await dataContext.Faqs.FirstOrDefaultAsync(x => x.Id == faqRequest.Id);

            return (await dataContext.SaveChangesAsync()) > 0;
        }
    }
}
