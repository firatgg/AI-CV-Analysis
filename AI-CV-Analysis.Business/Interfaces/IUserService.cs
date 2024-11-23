using AI_CV_Analysis.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CV_Analysis.Business.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user, string password);
        Task<string> AuthenticateUserAsync(string email, string password);
    }
}
