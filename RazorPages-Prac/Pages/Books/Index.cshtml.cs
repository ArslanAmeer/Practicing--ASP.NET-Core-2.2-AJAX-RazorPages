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

        //public List<Book> Books { get; set; }

        public async Task<IActionResult> OnGetAllBooks()
        {
            using (_db)
            {
                return new JsonResult(await _db.Books.ToListAsync());
            }
        }

    }
}