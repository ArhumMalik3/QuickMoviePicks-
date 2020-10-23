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
            string url = "https://rapidapi.p.rapidapi.com/search?start_year=1972&orderby=rating&audiosubtitle_andor=and&limit=100&subtitle=english&countrylist=78%2C46&audio=english&country_andorunique=unique&offset=0&end_year=2019"; //your API url goes here
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
