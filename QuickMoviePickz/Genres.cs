using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickMoviePickz
{
    public class Genres
    {
        public string GetGenreURL()
        {
            return $"https://unogsng.p.rapidapi.com/genres" + PrivateAPIKeys.GenreAPIKey;
        }

        public async Task GetGenres()
        {
            string url = GetGenreURL(); //your API url goes here
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JObject data = JsonConvert.DeserializeObject<JObject>(jsonResult);
            }

        }
    }
}
