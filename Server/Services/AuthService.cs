using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Server.Data.Interfaces;
using Server.Models;
using Server.Services.Interfaces;
using FreeBnB.Shared;

namespace Server.Services
{
  public class AuthService : IAuthService
  {
    private readonly IAuthRepository _authRepo;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public AuthService(IAuthRepository authRepo, IMapper mapper, IConfiguration config)
    {
      _config = config;
      _mapper = mapper;
      _authRepo = authRepo;
    }

    public async Task<TokenDto> Login(UserLoginDto userLogin)
    {
      var user = await _authRepo.Login(userLogin);

      if (user != null)
      {
        return CreateToken(user);
      }

      return null;
    }

    public async Task<bool> Register(UserForRegister userForRegister)
    {
      var userExists = await _authRepo.UserExists(userForRegister.Username);

      if (userExists)
      {
        throw new Exception("User with this email already exists.");
      }

      var user = _mapper.Map<User>(userForRegister);

      var userCreated = await _authRepo.Register(user, userForRegister.Password);

      return userCreated != null;
    }

    private TokenDto CreateToken(User user)
    {
      var claims = new[]
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username)
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
      var tokenDesciptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDesciptor);

      return new TokenDto() { Token = tokenHandler.WriteToken(token) };
    }
  }
}
