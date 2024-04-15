using EPosta.Entity.Concrete;
using EPosta.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EPosta.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppRegisterModelView p)
        {
            AppUser user = new AppUser()
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.EMail,
                ImageUrl = p.ImageUrl,
                UserName = p.UserName

            };
            if(p.Password==p.ConfirmedPassword)
            {
                var result = await _userManager.CreateAsync(user,p.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
    }
}
