using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_Prac.Model;

namespace RazorPages_Prac.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAllBooks()
        {
            using (_db)
            {
                return new JsonResult(await _db.Books.ToListAsync());
            }
        }

        public IActionResult OnDeleteDeleteBook(int bookId)
        {
            Book book = new Book();
            using (_db)
            {
                book = _db.Books.Find(bookId);
                _db.Books.Remove(book);
                _db.SaveChanges();
            }
            return new JsonResult($"{book.Name}: Deleted Successfully");
        }

        public async Task<IActionResult> OnPostAddBook([FromBody] Book book)
        {
            using (_db)
            {
                _db.Books.Add(book);
                await _db.SaveChangesAsync();
            }
            return new JsonResult($"{book.Name}: Added Successfully");
        }

        public async Task<IActionResult> OnPutUpdateBook([FromBody] Book book)
        {
            using (_db)
            {
                _db.Books.Update(book);
                await _db.SaveChangesAsync();
            }
            return new JsonResult($"{book.Name}: Update Successfully");
        }
    }
}