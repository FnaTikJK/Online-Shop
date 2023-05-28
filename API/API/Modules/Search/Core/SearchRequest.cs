namespace API.Modules.Search.Core
{
    public class SearchRequest
    {
        public string text { get; set; } = "";
        public HashSet<Guid>? categoriesId { get; set; }
        public int pageSize { get; set; } = 5;
        public int pageNumber { get; set; } = 1;
    }
}
