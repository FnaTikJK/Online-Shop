using API.Modules.Category.DTO;

namespace API.Modules.Search.DTO
{
    public class FiltersDTO
    {
        public IEnumerable<CategoryShortDTO> Categories { get; set; }
        public double From { get; set; }
        public double To { get; set; }
    }
}
