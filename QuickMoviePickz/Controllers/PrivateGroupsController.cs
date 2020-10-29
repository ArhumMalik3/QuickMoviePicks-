using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using QuickMoviePickz.Data;
using QuickMoviePickz.Models;
using QuickMoviePickz.ViewModels;
using RestSharp;
using RestSharp.Serialization.Json;

namespace QuickMoviePickz.Controllers
{
    public class PrivateGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrivateGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrivateGroups
        public async Task<IActionResult> Index()
        {
            MovieAPi movieAPi = new MovieAPi();
            await movieAPi.GetMovies();
           
            return View(await _context.PrivateGroups.ToListAsync());
        }

        // GET: PrivateGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privateGroup = await _context.PrivateGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (privateGroup == null)
            {
                return NotFound();
            }

            PrivateGroupDetailsViewModel viewModel = new PrivateGroupDetailsViewModel();
            viewModel.PrivateGroup = privateGroup;

            List<MovieWatcher> movieWatchers = await _context.MovieWatchers.Where(m => m.MyPrivateGroup == privateGroup).ToListAsync();


            return View(viewModel);
        }

        public void Random()
        {

        }

        public IActionResult RankMovies(int? id)
        {
            var privateGroup = _context.PrivateGroups.FirstOrDefault(g => g.Id == id);
            PrivateGroupRankMoviesViewModel rankMoviesViewModel = new PrivateGroupRankMoviesViewModel();
            rankMoviesViewModel.PrivateGroup = privateGroup;

            List<MovieWatcher> movieWatchers = _context.MovieWatchers.Where(m => m.MyPrivateGroup == privateGroup).ToList();
            //foreach (var person in movieWatchers)
            //{

            //}
            return View(rankMoviesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RankMovies(PrivateGroupRankMoviesViewModel rankMoviesViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movieWatcher = _context.MovieWatchers.Where(m => m.IdentityUserId == userId).First();
            movieWatcher.MyPrivateGroup.MovieRanking.MovieRating1 += rankMoviesViewModel.MovieRating1;
            movieWatcher.MyPrivateGroup.MovieRanking.MovieRating2 += rankMoviesViewModel.MovieRating2;
            movieWatcher.MyPrivateGroup.MovieRanking.MovieRating3 += rankMoviesViewModel.MovieRating3;
            movieWatcher.MyPrivateGroup.MovieRanking.MovieRating4 += rankMoviesViewModel.MovieRating4;
            movieWatcher.MyPrivateGroup.MovieRanking.MovieRating5 += rankMoviesViewModel.MovieRating5;
            _context.MovieWatchers.Update(movieWatcher);
            _context.SaveChanges();

            //int numberOfPeopleInGroup = rankMoviesViewModel.MovieWatchers.Count;
            //int totalRating = rankMoviesViewModel.MovieRating1;
            //int averageRatingOfMovie = totalRating / numberOfPeopleInGroup;

            //MovieRanking movieRanking = new MovieRanking();
            //movieRanking.MovieRating1 = averageRatingOfMovie;

            //var privateGroup = _context.PrivateGroups.FirstOrDefault(g => g.Id == rankMoviesViewModel.GroupId);
            //< input type = "hidden" asp -for= "GroupId" value = "@Model.PrivateGroup.Id" />
            return View();
        }

        public IActionResult GetGroupInformation(PrivateGroup privateGroup)
        {
            List<MovieWatcher> movieWatchers =  _context.MovieWatchers.Where(m => m.MyPrivateGroup == privateGroup).ToList();
            List<GenreId> genres = null;
            foreach (var person in movieWatchers)
            {

                genres.Add(person.Questionnaire.Genre);
            }
            return View();
        }

        public IActionResult GetMovies()
        {

            var genreList = "920,6839,7442";
            var type = "movie";
            var startYear = "1995";
            var countryList = "78,46";

            var client = new RestClient("https://rapidapi.p.rapidapi.com/search?genrelist=920,6839,7442&type=movie&start_year=1995&orderby=rating&limit=5&countrylist=78,46&audio=english&offset=0&end_year=2019");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "unogsng.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", PrivateAPIKeys.MovieSearchAPIKey);
            IRestResponse response = client.Execute(request);
            
            //string jsonResult = response.Content.ToString();
            if (response.IsSuccessful)
            {
                var deserialize = new JsonDeserializer();
                var output = deserialize.Deserialize<Dictionary<string, string>>(response);
                var movies = output["results"];
                
                
                //JObject data = JsonConvert.DeserializeObject<JObject>(jsonResult);
                ViewBag.movie = movies;


                //JObject jobject = JObject.Parse(data.ToString());
                //string movies = (string)jobject["synopsis"];
                //ViewBag.movie = movies;

            }
            
            return View();
        }

        public IActionResult GetGenres()
        {
            var client = new RestClient("https://unogsng.p.rapidapi.com/genres");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "unogsng.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", PrivateAPIKeys.GenreAPIKey);
            IRestResponse response = client.Execute(request);
            
            if (response.IsSuccessful)
            {
                string data = response.Content.ToString();
                JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);
                JToken results = jsonResults["genre"];
                ViewBag.genres = results;
            }
            return View();
        }

        // GET: PrivateGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrivateGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Pin")] PrivateGroup privateGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(privateGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(privateGroup);
        }

        // GET: PrivateGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privateGroup = await _context.PrivateGroups.FindAsync(id);
            if (privateGroup == null)
            {
                return NotFound();
            }
            return View(privateGroup);
        }

        // POST: PrivateGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Pin")] PrivateGroup privateGroup)
        {
            if (id != privateGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privateGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivateGroupExists(privateGroup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(privateGroup);
        }

        // GET: PrivateGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privateGroup = await _context.PrivateGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (privateGroup == null)
            {
                return NotFound();
            }

            return View(privateGroup);
        }

        // POST: PrivateGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var privateGroup = await _context.PrivateGroups.FindAsync(id);
            _context.PrivateGroups.Remove(privateGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivateGroupExists(int id)
        {
            return _context.PrivateGroups.Any(e => e.Id == id);
        }
    }
}
