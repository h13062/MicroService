using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingCore.Models
{
    public class JobRequirementResponseModel
    {
        public int JobRequirementId { get; set; }
        public int NumberOfPositions { get; set; }

        [MaxLength(512)]
        public string Title { get; set; }

        [MaxLength(int.MaxValue)]
        public string Description { get; set; }

        //Need to ask sharma clarification
        public int HiringManagerId { get; set; }
        [MaxLength(int.MaxValue)]
        public string HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActivate { get; set; }
        public DateTime ClosedOn { get; set; }

        [MaxLength(int.MaxValue)]
        public string ClosedReason { get; set; }
        public DateTime CreatedOn { get; set; }
        //ask sharma 
        [MaxLength(int.MaxValue)]
        public string? JobCategory { get; set; }
        //ask sharma 
        [MaxLength(int.MaxValue)]
        public string? EmployeeType { get; set; }

    }
}
