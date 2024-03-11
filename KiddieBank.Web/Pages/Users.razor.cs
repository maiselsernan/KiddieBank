using KiddieBank.DTOs;

namespace KiddieBank.Web.Pages
{
    public partial class Users
    {
        private List<UserDto> _users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _users = (await _userService.GetUsersAsync()).ToList();
        }
    }
}
