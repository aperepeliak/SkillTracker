namespace ST.WebUI.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public string UserName => string.Concat(FirstName, " ", LastName);
    }
}