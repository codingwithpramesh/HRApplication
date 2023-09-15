using HRApplication.Models;
using HRApplication.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HRApplication.Data.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
       
       
        public UserAuthenticationService(SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> rolemanager, UserManager<ApplicationUser> userManager, IEmailService emailService, IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
            _rolemanager = rolemanager;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _configuration = configuration;
        }


        public async Task<Status> LoginAsync(LoginVM loginVM)
        {
            var status = new Status();
            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user == null)
            {
                status.StatusCode=0;
                status.StatusMessage = "Invalid User";
                return status;
            }
            if (!await _userManager.CheckPasswordAsync(user, loginVM.Password))
            {
                status.StatusCode=0;
                status.StatusMessage ="Invalid Password";
                return status;
            }

            var signinResult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, true);
            if (signinResult.Succeeded)
            {
                
                var userroles = await _userManager.GetRolesAsync(user);
                var authclaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginVM.UserName)

                };

                foreach (var userrole in userroles)
                {
                    authclaims.Add(new Claim(ClaimTypes.Role, userrole));

                }
               
                status.StatusCode = 1;
                status.StatusMessage = "Login Successfully";
                return status;
            }
            else if (signinResult.IsLockedOut)
            {
                status.StatusCode=0;
                status.StatusMessage = "User Lockout";
            }
            else
            {
                status.StatusCode =0;
                status.StatusMessage="Invalid User";
                return status;
            }

            return status;

        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<Status> RegisterAsync(Registration Register)
        {
          var status = new Status();
            var userExists = await _userManager.FindByNameAsync(Register.Username);
           /* if (userExists != null)
            {
                status.StatusCode = 0;
                status.StatusMessage = "User already exist";
                return status;
            }*/
            if (Register.EmployeeId !=0)
            {
                Employee employee = _context.Employee.FirstOrDefault(x => x.Id == Register.EmployeeId);
                if (employee != null)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        Email = employee.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = Register.Username,
                        Name = employee.Name,
                        EmployeeId =employee.Id,
                        NormalizedEmail = employee.Email,
                        ProfilePicture = employee.profilepicture,
                        Role = employee.Role.ToString(),
                        EmailConfirmed=true,
                        PhoneNumberConfirmed=true,
                    };
                    var result = await _userManager.CreateAsync(user, Register.Password);
                    if (result.Succeeded)
                    {
                        status.StatusCode = 1;
                        status.StatusMessage = "User Successfully Registered";
                        return status;
                    }

                }
            }
            else
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = Register.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = Register.Username,
                    Name = Register.Name,
                    EmployeeId =Register.Id,
                    ProfilePicture = Register.ProfilePicture,
                    Role = Register.Roles.ToString(),
                    EmailConfirmed=true,
                    PhoneNumberConfirmed=true,
                };
                var result = await _userManager.CreateAsync(user, Register.Password);
                if (!result.Succeeded)
                {
                    status.StatusCode = 0;
                    status.StatusMessage = "User creation failed";
                    return status;
                }

                if (!await _rolemanager.RoleExistsAsync(Register.Roles))
                    await _rolemanager.CreateAsync(new IdentityRole(Register.Roles));


                if (await _rolemanager.RoleExistsAsync(Register.Roles))
                {
                    await _userManager.AddToRoleAsync(user, Register.Roles);
                }
            }

            status.StatusCode = 1;
            status.StatusMessage = "You have registered successfully";
           // await GenerateEmailConfirmationTokenAsync(user);
            // await _emailService.SendEmailAsync("sandbox.smtp.mailtrap.io", "Test Email", "This is a test email from Mailtrap.");
            return status;
        }

        public async Task<Status> ChangePasswordAsync(ChangePassword model, string username)
        {
            var status = new Status();

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                status.StatusMessage = "User does not exist";
                status.StatusCode = 0;
                return status;
            }
            var result = await _userManager.ChangePasswordAsync(user, model.NewPassword, model.NewPassword);
            if (result.Succeeded)
            {
                status.StatusMessage = "Password has updated successfully";
                status.StatusCode = 1;
            }
            else
            {
                status.StatusMessage = "Some error occcured";
                status.StatusCode = 0;
            }
            return status;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        {
            return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        }

        public async Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailConfirmationEmail(user, token);
            }
        }

        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailConfirmationEmail(user, token);
            }
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        private async Task SendForgotPasswordEmail(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("SMTPConfig:SenderAddress").Value;
            string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForForgotPassword(options);
        }

        private async Task SendEmailConfirmationEmail(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForEmailConfirmation(options);
        }


      public int GetId( int id)
        {
            var data = _context.EmployeeAttendence.Find(id);
            return data.Id;
        }


    }
}
