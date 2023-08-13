using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using OnlineCaterer.Application.Common.Interfaces.Data;
using OnlineCaterer.Data.Identity;
using OnlineCaterer.Domain.Entities;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Web.Models.Caterer;
using OnlineCaterer.Domain.Constants;

namespace OnlineCaterer.Web.Controllers.Users
{
    public class CatererController : Controller
    {
        private readonly IRepository<Caterer> _catererRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<CatererController> _logger;
        private readonly IEmailSender _emailSender;

        public CatererController(
            IRepository<Caterer> catererRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<CatererController> logger,
            IEmailSender emailSender
            )
        {
            _catererRepository = catererRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(CatererRegisterViewModel request)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = request.Email,
                    Email = request.Email,
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, ConstantsRoles.Caterer);

                    var userId = await _userManager.GetUserIdAsync(user);

                    Caterer caterer = new()
                    {
                        UserId = userId,
                        Name = request.Name,
                        Address = request.Address,
                    };

                    _catererRepository.Insert(caterer);
                    await _catererRepository.SaveChangesAsync();

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var returnUrl = Url.Content("~/");
                    var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    if (callbackUrl != null)
                    {
                        await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    }
                    #if(HasMailServer)
                    //return RedirectToPage("RegisterConfirmation", new { email = user.Email, returnUrl = returnUrl });
                    #endif

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string catererName)
        {
			List<Caterer> caterers = new();

			if (catererName != null)
            {
				caterers = await _catererRepository.GetQueryable()
                                .Where(c => c.Name != null && c.Name.Equals(catererName))
                                .ToListAsync();
			}

			return View(caterers);
        }
    }
}
