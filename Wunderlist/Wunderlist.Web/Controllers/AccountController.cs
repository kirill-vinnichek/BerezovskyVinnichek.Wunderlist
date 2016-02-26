using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Web.Models;
using Epam.Wunderlist.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Epam.Wunderlist.Web.Controllers
{
    //TODO: Избавится от EF в Web проекте. Спросить как?
    [Authorize]
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        private readonly UserManager<OwinUser> _userManager;

        public AccountController(IUserService userService,UserManager<OwinUser,int> userManager)
        {
            this._userService = userService;
            this._userManager = userManager;
        }

        [AllowAnonymous]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindAsync(viewModel.Email, viewModel.Password);
                if (user != null)
                {
                    await SignInAsync(user, true);
                    //TODO:  Change To Profile
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(viewModel);
        }

        [AllowAnonymous]
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        // GET: Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new OwinUser() { UserName = viewModel.UserName,Email = viewModel.Email };
               
                var result = await userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }
            // If we got this far, something failed, redisplay form
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }



        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async System.Threading.Tasks.Task SignInAsync(OwinUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}