using API.Modules.Account.Core;

namespace API.Modules.Account.Ports
{
    public interface IUsersRepository
    {
        public Task<Buyer> GetUserByLoginAsync(string login);
        public Task<Buyer?> GetUserByIdAsync(Guid id);
        public Task AddAsync(Buyer buyer);
        public Task SaveChangesAsync();
    }
}
