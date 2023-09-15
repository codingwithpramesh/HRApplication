using HRApplication.Models;
using HRApplication.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace HRApplication.Data.Services
{
    public interface IUserAuthenticationService
    {
        Task<Status> ChangePasswordAsync(ChangePassword model, string username);
        Task<Status> LoginAsync(LoginVM loginVM);

        Task LogoutAsync();

        Task<Status> RegisterAsync(Registration Register);

        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

        Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);

        Task GenerateForgotPasswordTokenAsync(ApplicationUser user);

        Task<ApplicationUser> GetUserByEmailAsync(string email);


        int GetId(int id);


    }
}
