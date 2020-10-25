using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickMoviePickz.Data;
using QuickMoviePickz.Models;
using QuickMoviePickz.ViewModels;

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
            Genres genres = new Genres();
            await genres.GetGenres();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RankMovies()
        {
            
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
