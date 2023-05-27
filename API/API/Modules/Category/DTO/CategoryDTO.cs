namespace API.Modules.Category.DTO
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]? Image { get; set; }
    }
}
