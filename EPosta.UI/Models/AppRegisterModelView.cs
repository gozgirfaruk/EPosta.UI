using System.ComponentModel.DataAnnotations;

namespace EPosta.UI.Models
{
    public class AppRegisterModelView
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Resim Url Boş Geçilemez")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler Eşleştirilemedi.")]
        public string ConfirmedPassword { get; set; }
    }
}
