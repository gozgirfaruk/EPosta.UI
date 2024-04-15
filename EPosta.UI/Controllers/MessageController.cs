using EPosta.Business.Concrete;
using EPosta.DataAccess.EntityFramework;
using EPosta.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EPosta.UI.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        AppMessageMenager _menager = new AppMessageMenager(new EfAppMessageDal());

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
