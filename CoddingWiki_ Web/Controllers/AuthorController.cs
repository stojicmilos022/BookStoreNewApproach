using CoddingWiki_DataAcess.Data;
using CoddingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CoddingWiki__Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Author> objList = _db.Authors;
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {


            Author obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id==id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    //create
                    await _db.Authors.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Authors.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {

            Author obj = new();

            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Authors.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
