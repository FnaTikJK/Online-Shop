using API.DAL;
using API.Modules.Account.Core;
using API.Modules.Profile.Ports;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Profile.Adapters
{
    public class ProfilesRepository : Repository<Buyer>, IProfilesRepository
    {
        public ProfilesRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Buyer> GetProfileAsync(string login)
        {
            return await Set.FirstOrDefaultAsync(e => e.Login == login);
        }
    }
}
