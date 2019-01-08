using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Publications.Web.Data;
using Publications.Web.Models.Publications;

namespace Publications.Web.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublicationsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index() => View(new OverviewModel(
            await _db.Authors.ToArrayAsync(), 
            await _db.Publications.ToArrayAsync()));

        #region CreateAuthor
        [HttpGet] public IActionResult CreateAuthor() => View();

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorInfo model)
        {
            if (!ModelState.IsValid) return View(model);
            _db.Authors.Add(new Author
            {
                Surname = model.AuthorSurname,
                Name = model.AuthorName,
                Patronymic = model.AuthorPatronimyc,
                Birthday = model.AuthorBirthday
            });
            await _db.SaveChangesAsync();
            return Redirect(nameof(Index));
        }
        #endregion

        #region EditAuthor
        [HttpGet]
        public async Task<IActionResult> EditAuthor(int id)
        {
            var author = await _db.Authors.FindAsync(id);
            if (author == null) Redirect(nameof(Index));
            var model = new AuthorInfo
            {
                Id = author.Id,
                AuthorName = author.Name,
                AuthorSurname = author.Surname,
                AuthorPatronimyc = author.Patronymic,
                AuthorBirthday = author.Birthday
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAuthor(AuthorInfo model)
        {
            if (!ModelState.IsValid) return View(model);
            var author = await _db.Authors.FindAsync(model.Id);
            if (author is null) return NotFound();
            author.Name = model.AuthorName;
            author.Patronymic = model.AuthorPatronimyc;
            author.Surname = model.AuthorSurname;
            author.Birthday = model.AuthorBirthday;
            await _db.SaveChangesAsync();
            return Redirect(nameof(Index));
        }
        #endregion

        #region RemoveAuthor
        [HttpPost]
        public async Task<IActionResult> RemoveAuthor(int Id)
        {
            var author = await _db.Authors.FindAsync(Id);
            if (author != null)
            {
                _db.Authors.Remove(author);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        } 
        #endregion

        #region CreatePublication

        [HttpGet] public IActionResult CreatePublication() => View(new PublicationInfo());

        [HttpPost]
        public async Task<IActionResult> CreatePublication(PublicationInfo model)
        {
            if (!ModelState.IsValid)return View(model);
            _db.Publications.Add(new Publication
            {
                Name = model.PublicationName,
                Date = model.PublicationDate
            });
            await _db.SaveChangesAsync();
            return Redirect(nameof(Index));
        }

        #endregion

        #region EditPublication
        [HttpGet]
        public async Task<IActionResult> EditPublication(int Id)
        {
            var publication = await _db.Publications.FindAsync(Id);
            if (publication is null) return NotFound();
            return View(new PublicationInfo
            {
                Id = publication.Id,
                PublicationName = publication.Name,
                PublicationDate = publication.Date
            });
        }

        public async Task<IActionResult> EditPublication(PublicationInfo model)
        {
            if (!ModelState.IsValid) return View(model);
            var publication = await _db.Publications.FindAsync(model.Id);
            if (publication is null) return NotFound();
            publication.Name = model.PublicationName;
            publication.Date = model.PublicationDate;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region RemovePublication
        [HttpPost]
        public async Task<IActionResult> RemovePublication(int Id)
        {
            var publication = await _db.Publications.FindAsync(Id);
            if (publication != null)
            {
                _db.Publications.Remove(publication);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        } 
        #endregion
    }
}