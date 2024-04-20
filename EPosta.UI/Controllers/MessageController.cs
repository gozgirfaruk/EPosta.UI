using EPosta.Business.Concrete;
using EPosta.DataAccess.Concrete;
using EPosta.DataAccess.EntityFramework;
using EPosta.Entity.Concrete;
using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace EPosta.UI.Controllers
{
    public class MessageController : Controller
    {
        AppMessageMenager _messageDal = new AppMessageMenager(new EfAppMessageDal());
        private readonly UserManager<AppUser> _userMenager;

        public MessageController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        public async Task<IActionResult> SenderMessage(string p, int page=1)
        {
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _messageDal.GetListSenderMessage(p).ToPagedList(page, 5);
            return View(messageList);
        }

        public IActionResult SenderMessageDetail(int id)
        {
            AppMessage message = _messageDal.GetById(id);
            return View(message);
        }
        public async Task<IActionResult> ReceiverMessage(string p,int page =1 )
        {
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            TempData["data"] = p;
            var messageList = _messageDal.GetListReceiverMessage(p).Where(x=>x.Status==true).ToPagedList(page,5);
           
            return View(messageList);
        }

        public IActionResult ReceiverMessageDetail(int id)
        {
            AppMessage message = _messageDal.GetById(id);
            return View(message);
        }

        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMessage(AppMessage p)
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
            _messageDal.TAdd(p);
            return RedirectToAction("SenderMessage");
        }

        public IActionResult Delete(int id)
        {
            var values = _messageDal.GetById(id);
            _messageDal.TUpdate(values);
            return RedirectToAction("ReceiverMessage");
        }

   

    }
}
