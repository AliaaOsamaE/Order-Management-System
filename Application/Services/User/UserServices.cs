using Application.Abstraction.Models.User;
using Application.Abstraction.Services.User;
using AutoMapper;
using Domain.Entities.Users;
using Domain.Exceptions;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services._User
{
    public class UserServices : IUserServices
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork, IConfiguration config, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _mapper = mapper;
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var user = (await _unitOfWork.GetRepository<User, int>().GetWhereAsync(u => u.Username == registerDto.Username)).FirstOrDefault();
            if (user is not null) throw new BadRequestException("Username already exists");
            var newUser = _mapper.Map<User>(registerDto);
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(registerDto.Password);
            var hash = sha.ComputeHash(bytes);
            newUser.Password = Convert.ToBase64String(hash);
            await _unitOfWork.GetRepository<User, int>().AddAsync(newUser);
            await _unitOfWork.CompleteAsync();
            var userDto = _mapper.Map<UserDto>(newUser);
            return userDto;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = (await _unitOfWork.GetRepository<User, int>().GetWhereAsync(u => u.Username == loginDto.Username)).FirstOrDefault();
            if (user is null) throw new NotFoundException("User not found");
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(loginDto.Password);
            var hash = sha.ComputeHash(bytes);
            var inputPassword = Convert.ToBase64String(hash);
            if (user.Password != inputPassword) throw new UnauthorizedAccessException("Invalid credentials");
            return await GenerateJwtToken(user);
        }

        private Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()), 
                new Claim("id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(jwt);
        }

    }
}
