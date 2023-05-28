using Microsoft.EntityFrameworkCore;
using API.DAL;
using API.Modules.Search.Core;
using API.Modules.Search.Ports;

namespace API.Modules.Search.Adapters
{
    public class SearchRepository : Repository<Product.Core.Product>, ISearchRepository
    {
        public SearchRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<(List<Product.Core.Product> items, int totalCount)> SearchInProducts(SearchRequest searchRequest)
        {
            var query = Set.AsNoTracking()
                .Include(p => p.Categories)
                .Where(p => p.Name.Contains(searchRequest.text)) //p.Name.Contains(searchRequest.text)
                .Where(p => searchRequest.categoriesId == null
                    || p.Categories.Count(c => searchRequest.categoriesId.Contains(c.Id)) == searchRequest.categoriesId.Count);
            var totalCount = query.Count();
            var result = await query
                .Skip(searchRequest.pageSize * (searchRequest.pageNumber - 1))
                .Take(searchRequest.pageSize)
                .ToListAsync();

            return (result, totalCount);
        }
    }
}
