using Microsoft.EntityFrameworkCore.Storage;

namespace API.Modules.Account.DTO
{
    public class RegDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string? ThirdName { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
