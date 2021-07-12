using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSO_LF089.Data;
using CSO_LF089.Models;
using CSO_LF089.Services;
using CSO_LF089.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CSO_LF089.Controllers
{
    [Authorize]
    public class CourseOrganizersController : Controller
    {
        private readonly CsoDbContext _context;

        public CourseOrganizersController(CsoDbContext context)
        {
            _context = context;
        }

        [Route("course-list")]
        public async Task<IActionResult> Index(string courseGenre,string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.CursesOrganizer orderby m.Subjects select m.Subjects;            

            var course = from c in _context.CursesOrganizer select c;

            if (!string.IsNullOrEmpty(searchString))
            {                
                course = course.Where(c => c.CourseName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(courseGenre))
            {
                course = course.Where(x => x.Subjects == courseGenre);
            }            

            var courseGenreVM = new CourseGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Courses = await course.ToListAsync(),                                
            };

            return View(courseGenreVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: details-product
        [Route("details-product/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseOrganizer = await _context.CursesOrganizer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseOrganizer == null)
            {
                return NotFound();
            }

            return View(courseOrganizer);
        }

        // GET: new-product
        [Route("new-product")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: new-product
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("new-product")]
        public async Task<IActionResult> Create([Bind("Id,CourseName,Subjects,CourseDuration,Status,Localization,purchased")] CourseOrganizer courseOrganizer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseOrganizer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseOrganizer);
        }

        // GET: edit-product
        [Route("edit-product/{id:int}")]       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseOrganizer = await _context.CursesOrganizer.FindAsync(id);
            if (courseOrganizer == null)
            {
                return NotFound();
            }
            return View(courseOrganizer);
        }

        // POST: edit-product
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit-product/{id:int}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,Subjects,CourseDuration,Status,Localization,purchased")] CourseOrganizer courseOrganizer)
        {
            if (id != courseOrganizer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseOrganizer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseOrganizerExists(courseOrganizer.Id))
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
            return View(courseOrganizer);
        }

        // GET: delete-product
        [Route("delete-product/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseOrganizer = await _context.CursesOrganizer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseOrganizer == null)
            {
                return NotFound();
            }

            return View(courseOrganizer);
        }

        // POST: delete-product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete-product/{id:int}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseOrganizer = await _context.CursesOrganizer.FindAsync(id);
            _context.CursesOrganizer.Remove(courseOrganizer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseOrganizerExists(int id)
        {
            return _context.CursesOrganizer.Any(e => e.Id == id);
        }
    }
}
