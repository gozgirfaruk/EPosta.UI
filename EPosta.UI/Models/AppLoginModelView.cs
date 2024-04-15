using System.ComponentModel.DataAnnotations;

namespace EPosta.UI.Models
{
    public class AppLoginModelView
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kayıtlı Kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Sisteme kayıtlı şifrenizi giriniz.")]
        public string Password { get; set; }
    }
}
