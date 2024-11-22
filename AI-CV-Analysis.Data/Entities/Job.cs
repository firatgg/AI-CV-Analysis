using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CV_Analysis.Data.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EmployerId { get; set; }

        // Navigation Properties
        public User Employer { get; set; } = null!;
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }


}
