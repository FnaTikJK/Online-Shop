using System.ComponentModel.DataAnnotations.Schema;

namespace API.Modules.Account.Core
{
    public class Buyer
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string? ThirdName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }


        public HashSet<Product.Core.Product> Favorites { get; set; }

        [NotMapped]
        public string FullName => SecondName + FirstName + (ThirdName ?? "");
    }
}
