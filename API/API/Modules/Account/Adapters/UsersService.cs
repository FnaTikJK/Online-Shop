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

        public async Task<Result<string>> RegisterUserAsync(RegDTO regDto)
        {
            var existed = await usersRepository.GetUserByLoginAsync(regDto.Login);
            if (existed != null)
                return Result.Fail<string>("Пользователь с таким логином уже существует");

            await usersRepository.AddAsync(mapper.Map<Buyer>(regDto));
            await usersRepository.SaveChangesAsync();

            return await LoginUserAsync(mapper.Map<AuthDTO>(regDto));
        }

        public async Task<Result<string>> LoginUserAsync(AuthDTO authDto)
        {
            var existed = await usersRepository.GetUserByLoginAsync(authDto.Login);
            if (existed == null)
                return Result.Fail<string>("Такого пользователя не существует");

            var cur = mapper.Map<Buyer>(authDto);
            if (cur.PasswordHash != existed.PasswordHash)
                return Result.Fail<string>("Неправильный пароль");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existed.Id.ToString()),
                new Claim(ClaimTypes.Name, existed.Login),
            };
            return Result.Ok(jwtService.CreateToken(claims));
        }
    }
}
