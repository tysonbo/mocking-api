using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeJellyApi.Models
{
    public class Policy
    {
        [Key]
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public string Product { get; set; }
        public string RiskType { get; set; }
        public string AgentCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SSN { get; set; }
    }
}
