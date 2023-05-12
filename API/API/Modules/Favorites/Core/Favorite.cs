using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Modules.Account.Core;

namespace API.Modules.Favorites.Core
{
    public class Favorite
    {
        public Buyer Buyer { get; set; }
        public Product.Core.Product Product { get; set; }
    }
}
