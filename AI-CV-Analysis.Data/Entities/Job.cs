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
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int EmployerId { get; set; }
        public User Employer { get; set; } = null!;
    }

}
