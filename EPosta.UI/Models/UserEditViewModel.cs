namespace EPosta.UI.Models
{
    public class UserEditViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PictureURL { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
