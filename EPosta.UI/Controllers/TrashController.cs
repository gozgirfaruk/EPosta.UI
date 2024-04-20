using EPosta.Business.Concrete;
using EPosta.DataAccess.EntityFramework;
using EPosta.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EPosta.UI.Controllers
{
    public class TrashController : Controller
    {
        AppMessageMenager _messageDal = new AppMessageMenager(new EfAppMessageDal());
        private readonly UserManager<AppUser> _userMenager;

        public TrashController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        public async Task<IActionResult> TrashBox(string p)
        {
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _messageDal.GetListReceiverMessage(p);
            var deger = messageList.Where(x => x.Status == false);
            return View(deger);
        }
    }
}
