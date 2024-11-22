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
        public Job Job { get; set; } = null!;
        public int ApplicantId { get; set; }
        public User Applicant { get; set; } = null!;
        public required string CVFilePath { get; set; }
        public double MatchScore { get; set; }

    }
}