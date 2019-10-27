using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data.Interfaces;
using Server.Models;
using FreeBnB.Shared;

namespace Server.Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;

    public AuthRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<User> Login(UserLoginDto user)
    {
      var foundUser = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == user.Username.ToLower());

      if (foundUser == null)
      {
        return null;
      }

      if (!VerifyPasswordHash(user.Password, foundUser.PasswordHash, foundUser.PasswordSalt))
      {
        return null;
      }

      return foundUser;
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
      {
        var computed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computed.Length; i++)
        {
          if (computed[i] != passwordHash[i])
          {
            return false;
          }
        }

        return true;
      }
    }

    public async Task<User> Register(User user, string password)
    {
      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password, out passwordHash, out passwordSalt);

      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;

      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();

      return user;
    }

    public async Task<bool> UserExists(string username)
    {
      var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

      return user != null;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }
  }
}
