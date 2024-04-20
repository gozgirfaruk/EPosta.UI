using EPosta.Business.Concrete;
using EPosta.DataAccess.Concrete;
using EPosta.DataAccess.EntityFramework;
using EPosta.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EPosta.UI.Controllers
{
    public class DraftController : Controller
    {
        DraftMenager _draftMenager = new DraftMenager(new EfDraftDal());
        private readonly UserManager<AppUser> _userMenager;

        public DraftController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        
        public async Task<IActionResult> DraftBox(string p)
        {
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _draftMenager.SendDraft(p);
           var deger = messageList.Where(x=>x.Status==true).ToList();
            return View(deger);
        }

        [HttpGet]
        public IActionResult DraftView()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DraftView(Draft p)
        {
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.FirstName + " " + values.LastName;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderMail = mail;
            p.SenderName = name;
            EPostaContext c = new EPostaContext();
            var username = c.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            p.ReceiverName = username;
            _draftMenager.TAdd(p);
            return RedirectToAction("DraftBox");
        }

        public IActionResult DraftDetail(int id)
        {
            var values = _draftMenager.GetById(id);
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var values = _draftMenager.GetById(id);
            _draftMenager.TDelete(values);
            return RedirectToAction("DraftBox");
        }
    }
}
