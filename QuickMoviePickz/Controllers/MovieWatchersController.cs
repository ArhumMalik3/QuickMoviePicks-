using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickMoviePickz.Data;
using QuickMoviePickz.Models;

namespace QuickMoviePickz.Controllers
{
    public class MovieWatchersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieWatchersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieWatchers
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movieWatcher = _context.MovieWatchers.Where(m => m.IdentityUserId ==
            userId).SingleOrDefault();
            
            if (movieWatcher == null)
            {

                return RedirectToAction("Create");
                
            }
            
            return View("Details", movieWatcher);
            //var applicationDbContext = _context.MovieWatchers.Include(m => m.IdentityUser).Include(m => m.Questionnaire);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: MovieWatchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieWatcher = await _context.MovieWatchers
                .Include(m => m.IdentityUser)
                .Include(m => m.Questionnaire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieWatcher == null)
            {
                return NotFound();
            }

            return View(movieWatcher);
        }

        // GET: MovieWatchers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["QuestionnaireId"] = new SelectList(_context.Questionnaires, "Id", "Id");
            return View();
        }

        // POST: MovieWatchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Country,QuestionnaireId,IdentityUserId")] MovieWatcher movieWatcher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieWatcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", movieWatcher.IdentityUserId);
            ViewData["QuestionnaireId"] = new SelectList(_context.Questionnaires, "Id", "Id", movieWatcher.QuestionnaireId);
            return View(movieWatcher);
        }

        // GET: MovieWatchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieWatcher = await _context.MovieWatchers.FindAsync(id);
            if (movieWatcher == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", movieWatcher.IdentityUserId);
            ViewData["QuestionnaireId"] = new SelectList(_context.Questionnaires, "Id", "Id", movieWatcher.QuestionnaireId);
            return View(movieWatcher);
        }

        // POST: MovieWatchers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Country,QuestionnaireId,IdentityUserId")] MovieWatcher movieWatcher)
        {
            if (id != movieWatcher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieWatcher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieWatcherExists(movieWatcher.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", movieWatcher.IdentityUserId);
            ViewData["QuestionnaireId"] = new SelectList(_context.Questionnaires, "Id", "Id", movieWatcher.QuestionnaireId);
            return View(movieWatcher);
        }

        // GET: MovieWatchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieWatcher = await _context.MovieWatchers
                .Include(m => m.IdentityUser)
                .Include(m => m.Questionnaire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieWatcher == null)
            {
                return NotFound();
            }

            return View(movieWatcher);
        }

        // POST: MovieWatchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieWatcher = await _context.MovieWatchers.FindAsync(id);
            _context.MovieWatchers.Remove(movieWatcher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieWatcherExists(int id)
        {
            return _context.MovieWatchers.Any(e => e.Id == id);
        }
    }
}
