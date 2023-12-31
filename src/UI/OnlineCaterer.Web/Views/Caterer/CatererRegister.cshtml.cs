
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Data.Identity;
using OnlineCaterer.Domain.Constants;
using OnlineCaterer.Web.Models.Caterer;
using System.Text;
using System.Text.Encodings.Web;

namespace OnlineCaterer.Web.Views.Caterer
{
    public class CatererRegister : PageModel
    {
        private readonly IRepository<Domain.Entities.Caterer> _catererRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public CatererRegister(
            IRepository<Domain.Entities.Caterer> catererRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender
            )
        {
            _catererRepository = catererRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public CatererCreateViewModel Input { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await _userManager.FindByEmailAsync(Input.Email) != null)
            {
                ModelState.AddModelError(string.Empty, "Email already exists");
                return Page();
            }

            ApplicationUser user = new()
            {
                UserName = Input.Email,
                Email = Input.Email,
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, ConstantsRoles.Caterer);

                var userId = await _userManager.GetUserIdAsync(user);
                Domain.Entities.Caterer caterer = new()
                {
                    UserId = userId,
                    Name = Input.Name,
                    Address = Input.Address,
                };
                _catererRepository.Insert(caterer);
                await _catererRepository.SaveChangesAsync();

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var returnUrl = Url.Content("~/");
                var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId, code, returnUrl },
                    protocol: Request.Scheme);

                if (callbackUrl != null)
                {
                    await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                }

                #if (HasMailServer)
                    //return RedirectToPage("RegisterConfirmation", new { email = user.Email, returnUrl = returnUrl });
                #endif

                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            return Page();
        }
    }
}
