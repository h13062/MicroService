using InterviewCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewInfrastructure.Data
{
    public class InterViewDbContext:  DbContext
    {
        public InterViewDbContext(DbContextOptions<InterViewDbContext> option): base(option)
        {

        }
        
        public DbSet<Interview> Interview { get; set; }
        public DbSet<Interviewer> Interviewer { get; set; }
        public DbSet<InterviewFeedBack> InterviewFeedBack { get; set; }
        public DbSet<InterviewType> interviewTypes { get; set; }
        public DbSet<Recruiter> Recruiter { get; set; }


    }
}
