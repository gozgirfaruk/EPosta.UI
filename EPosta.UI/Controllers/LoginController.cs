using EPosta.Entity.Concrete;
using EPosta.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EPosta.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppLoginModelView p)
        {
            if(ModelState.IsValid)
            {
                var result =await _signInManager.PasswordSignInAsync(p.UserName,p.Password,false,true);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Message");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı e-posta veya şifre.");
                }
            }
            return View();
        }
    }
}
