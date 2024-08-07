using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Security
{
    public class CodeGenerator
    {
        private static readonly Random _random = new Random();
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYQ0123456789";

        public static string GenerateRandomCode(int length)
        {
            return new string(Enumerable.Repeat(Characters, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}