using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Publications.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly ILogger<RegisterModel> _Logger;
        private readonly IEmailSender _EmailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender EmailSender)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _Logger = logger;
            _EmailSender = EmailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Электронная почта")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} доллжно быть от {2} и не больше {1} символов.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Пароль")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Повторите ввод пароля")]
            [Compare(nameof(Password), ErrorMessage = "Пароль и его подтверждение не совпадают.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null) => ReturnUrl = returnUrl;

        public async Task<IActionResult> OnPostAsync(string ReturnedUrl = null)
        {
            ReturnedUrl = ReturnedUrl ?? Url.Content("~/");
            if (!ModelState.IsValid) return Page();
            var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
            var result = await _UserManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                _Logger.LogInformation("Пользователь создал новую учётную запись с паролем.");

                var code = await _UserManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = user.Id, code = code },
                    protocol: Request.Scheme);

                await _EmailSender.SendEmailAsync(Input.Email, "Подтвердите вашу электронную почту",
                    $"Пожалуйста, подтвердите Вашу электронную почту <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>переходом по этой ссылке</a>.");

                await _SignInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(ReturnedUrl);
            }
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }
    }
}
