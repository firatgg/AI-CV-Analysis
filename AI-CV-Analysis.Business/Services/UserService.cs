using AI_CV_Analysis.Business.Interfaces;
using AI_CV_Analysis.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace AI_CV_Analysis.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> AuthenticateUserAsync(string email, string password)
        {
            // Kullanıcı giriş işlemi
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return "User not found";

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded ? "Login successful" : "Invalid credentials";
        }

        public async Task<bool> RegisterUserAsync(User user, string password)
        {
            // Kullanıcı kayıt işlemi
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }
    }
}
