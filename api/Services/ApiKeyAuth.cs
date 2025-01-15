using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class ApiKeyAuth(string apiKey)
    {
        private string? _expectedApiKey = Environment.GetEnvironmentVariable("SERVER_API_KEY");
        private bool authorized = false;

        public bool keyAuth()
        {
            if (string.IsNullOrEmpty(apiKey) || apiKey != _expectedApiKey)
            {
                authorized = false;
            }
            else if (apiKey == _expectedApiKey)
            {
                authorized = true;
            }
            return authorized;
        }

    }
}