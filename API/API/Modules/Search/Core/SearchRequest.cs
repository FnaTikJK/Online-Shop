namespace API.Modules.Search.Core
{
    public class SearchRequest
    {
        public string Text { get; set; }
        public HashSet<Guid>? CategoriesId { get; set; }
        public int PageSize { get; set; } = 5;
        public int PageNumber { get; set; } = 1;
    }
}
