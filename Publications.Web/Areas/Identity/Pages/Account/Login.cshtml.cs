using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Publications.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly ILogger<LoginModel> _Logger;

        public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
        {
            _SignInManager = signInManager;
            _Logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Имя пользователя")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Запомнить?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string ReturnedUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage)) ModelState.AddModelError(string.Empty, ErrorMessage);

            ReturnedUrl = ReturnedUrl ?? Url.Content("~/");

            // Очищаем существующие внешние записи для того, что бы удостовериться в правильности процесса входа
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = ReturnedUrl;
        }

        public async Task<IActionResult> OnPostAsync(string ReturnedUrl = null)
        {
            ReturnedUrl = ReturnedUrl ?? Url.Content("~/");

            // If we got this far, something failed, redisplay form
            if (!ModelState.IsValid) return Page();

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _SignInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                _Logger.LogInformation("Пользователь вошёл.");
                return LocalRedirect(ReturnedUrl);
            }
            if (result.RequiresTwoFactor)
                return RedirectToPage("./LoginWith2fa", new {ReturnUrl = ReturnedUrl, RememberMe = Input.RememberMe});
            if (result.IsLockedOut)
            {
                _Logger.LogWarning("Пользовательская учётная запись заблокирована.");
                return RedirectToPage("./Lockout");
            }

            ModelState.AddModelError(string.Empty, "Провальная попытка входа.");
            return Page();

        }
    }
}
