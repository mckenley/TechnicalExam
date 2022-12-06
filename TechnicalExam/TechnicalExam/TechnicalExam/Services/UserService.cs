using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechnicalExam.Models;

namespace TechnicalExam.Services
{
    public class UserService : IUserService
    {
        private const string GetUsersEndpoint = 
            "https://gist.githubusercontent.com/erni-ph-mobile-team/c5b401c4fad718da9038669250baff06/raw/7e390e8aa3f7da4c35b65b493fcbfea3da55eac9/test.json";

        private HttpClient _client;

        public UserService()
        {
            _client = new HttpClient();
        }

        public async Task<List<UserModel>> GetUsers()
        {
            Uri uri = new Uri(GetUsersEndpoint);

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<UserModel> result = JsonConvert.DeserializeObject<List<UserModel>>(content);
                List<UserModel> filteredResult = result.GroupBy(u => u.Id)
                                                       .Select(u => u.FirstOrDefault())
                                                       .ToList();
                return filteredResult;
            }

            return null;
        }
    }
}
