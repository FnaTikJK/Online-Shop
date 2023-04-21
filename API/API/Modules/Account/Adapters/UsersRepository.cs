using API.DAL;
using API.Modules.Account.Core;
using API.Modules.Account.Ports;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Account.Adapters
{
    public class UsersRepository : Repository<Buyer>, IUsersRepository
    {
        public UsersRepository(DataContext dataContext) : base(dataContext)
        {
        }


        public async Task<Buyer> GetUserByLoginAsync(string login)
        {
            return await Set.FirstOrDefaultAsync(e => e.Login == login);
        }

        public async Task AddAsync(Buyer buyer)
        {
            await Set.AddAsync(buyer);
        }
    }
}
