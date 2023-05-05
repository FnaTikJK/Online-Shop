using API.Modules.Search.Core;

namespace API.Modules.Search.Ports
{
    public interface ISearchRepository
    {
        public Task<(List<Product.Core.Product> items, int totalCount)> SearchInProducts(SearchRequest searchRequest);
    }
}
