using API.Modules.Search.DTO;

namespace API.Modules.Search.Core
{
    public class SearchResponse
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<ProductShortDTO> Items { get; set; }
    }
}
