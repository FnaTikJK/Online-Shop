namespace API.Modules.Search.Core
{
    public class SearchRequest
    {
        public string text { get; set; } = "";
        public HashSet<Guid>? categoriesId { get; set; }
        public int pageSize { get; set; } = 6;
        public int pageNumber { get; set; } = 1;
        public double priceFrom { get; set; } = 0;
        public double priceTo { get; set; } = double.MaxValue;
        public OrderBy? orderBy { get; set; } = null;
        public bool descending { get; set; } = false;
    }

    public enum OrderBy
    {
        Name,
        Price
    }
}
