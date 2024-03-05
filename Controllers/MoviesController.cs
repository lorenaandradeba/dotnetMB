using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.AspNetCore.Authorization;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }
        // GET: Movies
        public async Task<IActionResult> Index()
        {
              return _context.Movie != null ? 
                          View(await _context.Movie
                          .Include(m => m.Studio).Include(m => m.Artists)
                          .ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Movie'  is null.");
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .Include(m => m.Studio).Include(m => m.Artists)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            // Obtenha a lista de Studios e artists do seu banco de dados ou serviço
            var studios = _context.Studio.ToList();
            var artists = _context.Artist.ToList();
            
            ViewBag.Studios = studios;
            ViewBag.Artists = artists;

            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,StudioId,ArtistId,ArtistMovie.ArtistsId,ArtistMovie.MoviesId")] Movie movie, List<int> selectedArtists)
        {
            if (ModelState.IsValid)
            {
                    // Adicione os novos Artists que foram selecionados
                    foreach (var artistId in selectedArtists)
                    {
                        if (!movie.Artists.Any(a => a.Id == artistId))
                        {
                            var artistToAdd = await _context.Artist.FindAsync(artistId);
                            movie.Artists.Add(artistToAdd!);
                        }
                    }
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.Include(m => m.Artists).FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            
            // Obtenha a lista de Studios e artists do seu banco de dados ou serviço
            var studios = _context.Studio.ToList();
            var artists = _context.Artist.ToList();
            
            ViewBag.Studios = studios;
            ViewBag.Artists = artists;
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,StudioId,ArtistId,ArtistMovie.ArtistsId, ArtistMovie.MoviesId")] Movie movie, List<int> selectedArtists)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Remova os Artists que não estão mais selecionados
                    var artistsToRemove = movie.Artists.Where(a => !selectedArtists.Contains(a.Id)).ToList();

                    // Remova os Artists que não estão mais selecionados
                    foreach (var artist in artistsToRemove)
                    {
                        movie.Artists.Remove(artist);
                    }

                    _context.Update(movie);
                    await _context.SaveChangesAsync();

                    // Adicione os novos Artists que foram selecionados
                    foreach (var artistId in selectedArtists)
                    {
                        if (!movie.Artists.Any(a => a.Id == artistId))
                        {
                            var artistToAdd = await _context.Artist.FindAsync(artistId);
                            movie.Artists.Add(artistToAdd!);
                        }
                    }

                    _context.Update(movie);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
