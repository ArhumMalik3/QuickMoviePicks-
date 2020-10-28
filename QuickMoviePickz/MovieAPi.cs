using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuickMoviePickz.Models;
using RestSharp;
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
            //string url = "https://rapidapi.p.rapidapi.com/search?genrelist=920&type=movie&start_year=1995&orderby=rating&limit=5&countrylist=78,46&audio=english&offset=0&end_year=2019"; //your API url goes here
            //HttpClient client = new HttpClient();

            //RestClient testclient = new RestClient();
            //testclient.AddDefaultHeader("x-rapidapi-host", "unogsng.p.rapidapi.com");
            //testclient.AddDefaultHeader("x-rapidapi-key", "7fc21d2f6fmsh556eee3141b6dccp10bbb5jsn231d81e227ed");
            //HttpResponseMessage response = await client.GetAsync(url);
            //IRestResponse response = client.Execute(request);
            


            var client = new RestClient("https://unogsng.p.rapidapi.com/search?genrelist=920&type=movie&start_year=1995&orderby=rating&audiosubtitle_andor=and&limit=5&subtitle=english&countrylist=78%252C46&audio=english&country_andorunique=unique&offset=0&end_year=2019");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "unogsng.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", PrivateAPIKeys.MovieSearchAPIKey);
            IRestResponse response =  client.Execute(request);
            

            //string jsonResult = await response.Content.ReadAsStringAsync();
            //if (response.IsSuccessStatusCode)
            //{
            //    JObject data = JsonConvert.DeserializeObject<JObject>(jsonResult);
            //}

        }

    }
}
