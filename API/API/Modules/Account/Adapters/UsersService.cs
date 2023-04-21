using System.Security.Claims;
using API.Infrastructure;
using API.Modules.Account.Core;
using API.Modules.Account.DTO;
using API.Modules.Account.Ports;
using AutoMapper;

namespace API.Modules.Account.Adapters
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;
        public UsersService(IUsersRepository usersRepository, IMapper mapper, IJwtService jwtService)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
            this.jwtService = jwtService;
        }

        public async Task<Result<ClaimsIdentity>> RegisterUserAsync(RegDTO regDto)
        {
            var existed = await usersRepository.GetUserByLoginAsync(regDto.Login);
            if (existed != null)
                return Result.Fail<ClaimsIdentity>("Пользователь с таким логином уже существует");

            await usersRepository.AddAsync(mapper.Map<Buyer>(regDto));
            await usersRepository.SaveChangesAsync();

            return await LoginUserAsync(mapper.Map<AuthDTO>(regDto));
        }

        public async Task<Result<ClaimsIdentity>> LoginUserAsync(AuthDTO authDto)
        {
            var existed = await usersRepository.GetUserByLoginAsync(authDto.Login);
            if (existed == null)
                return Result.Fail<ClaimsIdentity>("Такого пользователя не существует");

            var cur = mapper.Map<Buyer>(authDto);
            if (cur.PasswordHash != existed.PasswordHash)
                return Result.Fail<ClaimsIdentity>("Неправильный пароль");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, authDto.Login),
                new Claim(ClaimTypes.Name, existed.FullName),
            };
            return Result.Ok(new ClaimsIdentity(claims, "Cookies"));
        }
    }
}
