using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSO_LF089.Data;
using CSO_LF089.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace CSO_LF089.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly CsoDbContext _context;

        public BooksController(CsoDbContext context)
        {
            _context = context;
        }

        // GET: Book-list
        [Route("books-list")]        
        public async Task<IActionResult> Index()
        {
            return View(await _context.books.ToListAsync());
        }

        // GET: details-book
        [Route("details-book/{id:int}")]        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        // GET: new-book
        [Route("new-book")]        
        public IActionResult Create()
        {
            return View();
        }

        // POST: new-book
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("new-book")]
        public async Task<IActionResult> Create([Bind("Id,BookName,BookSubject,Author,Language,ReadingStatus,ImageFile")] Book book, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                string wwwrootPath = Directory.GetCurrentDirectory() + "/wwwroot";
                string FileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                string extension = Path.GetExtension(book.ImageFile.FileName);
                book.ImageName = FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwrootPath + "/img/" + FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await book.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET:edit-book
        [Route("edit-book/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: edit-book
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit-book/{id:int}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookName,BookSubject,Author,Language,ReadingStatus,Image")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            return View(book);
        }

        // GET: delete-book
        [Route("delete-book/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        
        // POST: delete-book
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete-book/{id:int}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.books.FindAsync(id);
            _context.books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.books.Any(e => e.Id == id);
        }
    }
}
