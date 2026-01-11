using Application.Abstraction.Models.User;

namespace Application.Abstraction.Services.User
{
    public interface IUserServices
    {
        public Task<string> Login(LoginDto loginDto);
        public Task<UserDto> Register(RegisterDto registerDto);
    }
}
