using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Publications.Web.Areas.Identity.Models;

namespace Publications.Web.Areas.Identity.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _Users;

        public UsersController(UserManager<IdentityUser> Users)
        {
            _Users = Users;
        }

        public async Task<IActionResult> Index()
        {
            return View(new UsersListModel(await _Users.Users.ToArrayAsync()));
        }
    }
}