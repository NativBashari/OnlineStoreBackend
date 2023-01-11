﻿using Contracts.RepositoriesContracts.Auth;
using Entities;
using Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly OnlineStoreDbContext dbContext;

        public AuthRepository(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string Login(string userName, string password)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Username!.ToLower().Equals(userName.ToLower()));
            if(user == null)
            {
                return string.Empty;
            }
            else if(!VerifyPasswordHash(password, user.PasswordHash!, user.PasswordSalt!))
            {
                return string.Empty;
            }
                return user.Id.ToString();
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
            if(dbContext.Users.Any(u => u.Username.ToLower() == username.ToLower()))
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
    }
}
