using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Publications.Web.Areas.Identity.Models;
using Publications.Web.Models;

namespace Publications.Web.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<IdentityUser> _Users;
        public HomeController(UserManager<IdentityUser> Users) => _Users = Users;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetUsers()
        {
            return View(new UsersListModel(await _Users.Users.ToArrayAsync()));
        }
    }
}
