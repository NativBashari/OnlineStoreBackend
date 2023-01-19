using Castle.Core.Configuration;
using Contracts.RepositoriesContracts.Auth;
using Entities;
using Microsoft.IdentityModel.Tokens;
using Models.DTO;
using Models.UserManagement;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly OnlineStoreDbContext dbContext;
        const string KEY = "my seceret json key";

        public AuthRepository(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public AuthenticatedResponse Login(string userName, string password)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Username!.ToLower().Equals(userName.ToLower()));
            if(user == null)
            {
                return new AuthenticatedResponse { IsSuccess = false, Message= "Username incorrect" };
            }
            else if(!VerifyPasswordHash(password, user.PasswordHash!, user.PasswordSalt!))
            {
                return new AuthenticatedResponse { IsSuccess = false, Message = "Password incorrect" };
            }
                return new AuthenticatedResponse { IsSuccess = true, Message = "Authenticated seccusfully", Token = CreateToken(user) };
        }

        public int Register(User user, string password)
        {
            if (UserExist(user.Username!)) return 0;
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user.Id; 
        }

        public bool UserExist(string username)
        {
            if(dbContext.Users.Any(u => u.Username!.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }
        private void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac= new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool IsAdmin(int id)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
            return user!.IsAdmin;
        }
    }
}
