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
                .Where(p => p.Name.Contains(searchRequest.Text)) //p.Name.Contains(searchRequest.Text)
                .Where(p => searchRequest.CategoriesId == null
                    || p.Categories.Count(c => searchRequest.CategoriesId.Contains(c.Id)) == searchRequest.CategoriesId.Count);
            var totalCount = query.Count();
            var result = await query
                .Skip(searchRequest.PageSize * (searchRequest.PageNumber - 1))
                .Take(searchRequest.PageSize)
                .ToListAsync();

            return (result, totalCount);
        }
    }
}
