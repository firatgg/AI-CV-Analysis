using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CV_Analysis.Data.Entities
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }


}
