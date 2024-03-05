using KiddieBank.Model.Models;

namespace KiddieBank.Web.Pages
{
    public partial class Users
    {
        private List<User> _users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _users = (await _userService.GetUsersAsync()).ToList();
        }
    }
}
