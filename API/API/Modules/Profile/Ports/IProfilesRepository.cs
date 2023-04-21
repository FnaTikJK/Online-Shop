using API.Modules.Account.Core;

namespace API.Modules.Profile.Ports
{
    public interface IProfilesRepository
    {
        public Task<Buyer> GetProfileAsync(string login);
        public Task SaveChangesAsync();
    }
}
