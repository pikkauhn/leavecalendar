using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Security
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            var hasher = new PasswordHasher<object>();
            var hashedPassword = hasher.HashPassword("", password);
            return hashedPassword;
        }

        public static PasswordVerificationResult VerifyPassword(string hashedPassword, string providedPassword)
        {
            var hasher = new PasswordHasher<object>();
            return hasher.VerifyHashedPassword("", hashedPassword, providedPassword);
        }
    }
}