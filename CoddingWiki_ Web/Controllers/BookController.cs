using CoddingWiki_DataAcess.Data;
using CoddingWiki_Model.Models;
using CoddingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoddingWiki__Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> objList=_db.Books;
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Upsert(BookVM obj)
        {

                if (obj.Book.BookId == 0)
                {
                    //create
                    await _db.Books.AddAsync(obj.Book);
                }
                else
                {
                //update
                _db.Books.Update(obj.Book);

                }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new();

            obj = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        //public IActionResult CreateMultiple2()
        //{
        //    List<Category> categories = new List<Category>();
        //    for (int i = 1; i <= 2; i++)
        //    {
        //        categories.Add(new Category { CategoryName=Guid.NewGuid().ToString() });
        //        //_db.SaveChanges();
        //    }
        //    _db.Categories.AddRange(categories);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult CreateMultiple5()
        //{
        //    List<Category> categories = new List<Category>();
        //    for (int i = 1; i <=5; i++)
        //    {
        //        categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
        //        //_db.SaveChanges();
        //    }
        //    _db.Categories.AddRange(categories);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult RemoveMultiple2()
        //{
        //    List<Category> categories = _db.Categories.OrderByDescending(u=>u.CategoryId).Take(2).ToList();

        //    _db.Categories.RemoveRange(categories);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult RemoveMultiple5()
        //{
        //    List<Category> categories = _db.Categories.OrderByDescending(u => u.CategoryId).Take(5).ToList();

        //    _db.Categories.RemoveRange(categories);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
