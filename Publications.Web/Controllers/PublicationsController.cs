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
            if (author is null) return Redirect(nameof(Index));
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
            if (!ModelState.IsValid) return View(model);
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

        #region AuthorsGrades
        public async Task<IActionResult> GetAuthorsGrades() => View(await _db.AuthorGrades.ToArrayAsync());
        public IActionResult CreateAuthorGrade() => View(nameof(EditAuthorGrade), new AuthorGradeInfo { Id = -1 });

        [HttpGet]
        public async Task<IActionResult> EditAuthorGrade(int id)
        {
            var grade = await _db.AuthorGrades.FindAsync(id);
            if (grade is null) return NotFound();
            return View(new AuthorGradeInfo
            {
                Id = grade.Id,
                Name = grade.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditAuthorGrade(AuthorGradeInfo model)
        {
            if (!ModelState.IsValid) return View(model);
            var grade = model.Id == -1 ? _db.AuthorGrades.Add(new AuthorGrade()).Entity : await _db.AuthorGrades.FindAsync(model.Id);
            if (grade is null) return NotFound();
            grade.Name = model.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetAuthorsGrades));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAuthorGrade(int id)
        {
            var grade = await _db.AuthorGrades.FindAsync(id);
            if (grade is null) return NotFound();
            _db.AuthorGrades.Remove(grade);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetAuthorsGrades));
        }
        #endregion

        #region AuthorsDegrees
        public async Task<IActionResult> GetAuthorsDegrees() => View(await _db.AuthorDegrees.ToArrayAsync());
        public IActionResult CreateAuthorDegree() => View(nameof(EditAuthorDegree), new AuthorDegreeInfo { Id = -1 });

        [HttpGet]
        public async Task<IActionResult> EditAuthorDegree(int id)
        {
            var degree = await _db.AuthorDegrees.FindAsync(id);
            if (degree is null) return NotFound();
            return View(new AuthorDegreeInfo
            {
                Id = degree.Id,
                Name = degree.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditAuthorDegree(AuthorDegreeInfo model)
        {
            if (!ModelState.IsValid) return View(model);
            var degree = model.Id == -1 ? _db.AuthorDegrees.Add(new AuthorDegree()).Entity : await _db.AuthorDegrees.FindAsync(model.Id);
            if (degree is null) return NotFound();
            degree.Name = model.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetAuthorsDegrees));

        }

        [HttpPost]
        public async Task<IActionResult> RemoveAuthorDegree(int id)
        {
            var degree = await _db.AuthorDegrees.FindAsync(id);
            if (degree is null) return NotFound();
            _db.AuthorDegrees.Remove(degree);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetAuthorsDegrees));
        }
        #endregion

        #region AuthorsPositions
        public async Task<IActionResult> GetAuthorsPositions() => View(await _db.AuthorPositions.ToArrayAsync());
        public IActionResult CreateAuthorPosition() => View(nameof(EditAuthorPosition), new AuthorPositionInfo { Id = -1 });

        [HttpGet]
        public async Task<IActionResult> EditAuthorPosition(int id)
        {
            var position =  await _db.AuthorPositions.FindAsync(id);
            if (position is null) return NotFound();
            return View(new AuthorPositionInfo
            {
                Id = position.Id,
                Name = position.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditAuthorPosition(AuthorPositionInfo model)
        {
            if (!ModelState.IsValid) return View(model);
            var position = model.Id == -1 ? _db.AuthorPositions.Add(new AuthorPosition()).Entity : await _db.AuthorPositions.FindAsync(model.Id);
            if (position is null) return NotFound();
            position.Name = model.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetAuthorsPositions));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAuthorPosition(int id)
        {
            var position = await _db.AuthorPositions.FindAsync(id);
            if (position is null) return NotFound();
            _db.AuthorPositions.Remove(position);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetAuthorsPositions));
        }
        #endregion

        #region PublicationPlace
        public async Task<IActionResult> GetPublicationPlaces() => View(await _db.PublicationPlaces.ToArrayAsync());
        public IActionResult CreatePublicationPlace() => View(nameof(EditPublicationPlace), new PublicationPlaceInfo { Id = -1 });

        [HttpGet]
        public async Task<IActionResult> EditPublicationPlace(int id)
        {
            var type = await _db.PublicationTypes.FindAsync(id);
            if (type is null) return NotFound();
            return View(new PublicationPlaceInfo
            {
                Id = type.Id,
                Name = type.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditPublicationPlace(PublicationPlaceInfo model)
        {
            if (!ModelState.IsValid) return View(model);
            var place = model.Id == -1 ? _db.PublicationPlaces.Add(new PublicationPlace()).Entity : await _db.PublicationPlaces.FindAsync(model.Id);
            if (place is null) return NotFound();
            place.Name = model.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetPublicationPlaces));
        }

        [HttpPost]
        public async Task<IActionResult> RemovePublicationPlace(int id)
        {
            var place = await _db.PublicationPlaces.FindAsync(id);
            if (place is null) return NotFound();
            _db.PublicationPlaces.Remove(place);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetPublicationPlaces));
        }
        #endregion

        #region PublicationTypes
        public async Task<IActionResult> GetPublicationTypes() => View(await _db.PublicationTypes.ToArrayAsync());
        public IActionResult CreatePublicationType() => View(nameof(EditPublicationType), new PublicationTypeInfo { Id = -1 });

        [HttpGet]
        public async Task<IActionResult> EditPublicationType(int id)
        {
            var type = await _db.PublicationTypes.FindAsync(id);
            if (type is null) return NotFound();
            return View(new PublicationTypeInfo
            {
                Id = type.Id,
                Name = type.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditPublicationType(PublicationTypeInfo model)
        {
            if (!ModelState.IsValid) return View(model);
            var type = model.Id == -1 ? _db.PublicationTypes.Add(new PublicationType()).Entity : await _db.PublicationTypes.FindAsync(model.Id);
            if (type is null) return NotFound();
            type.Name = model.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetPublicationTypes));
        }

        [HttpPost]
        public async Task<IActionResult> RemovePublicationType(int id)
        {
            var type = await _db.PublicationTypes.FindAsync(id);
            if (type is null) return NotFound();
            _db.PublicationTypes.Remove(type);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(GetPublicationTypes));
        }
        #endregion
    }
}