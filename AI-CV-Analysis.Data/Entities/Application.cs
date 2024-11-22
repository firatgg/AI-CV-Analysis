using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CV_Analysis.Data.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int ApplicantId { get; set; }
        public string CVFilePath { get; set; } = string.Empty;
        public float MatchScore { get; set; }

        // Navigation Properties
        public Job Job { get; set; } = null!;
        public User Applicant { get; set; } = null!;
    }

}