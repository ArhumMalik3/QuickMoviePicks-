using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuickMoviePickz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickMoviePickz
{
    public class MovieAPi
    {

        public async Task GetMovies()
        {
            string url = "https://rapidapi.p.rapidapi.com/search?genrelist=920&type=movie&start_year=1995&orderby=rating&limit=5&countrylist=78,46&audio=english&offset=0&end_year=2019"; //your API url goes here
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
