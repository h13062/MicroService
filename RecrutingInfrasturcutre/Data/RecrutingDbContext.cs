using Microsoft.EntityFrameworkCore;
using RecruitingCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutingInfrasturcutre.Data
{
    public class RecrutingDbContext : DbContext
    {
        public RecrutingDbContext(DbContextOptions<RecrutingDbContext> option ):   base(option)     
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(builder =>
            {
                builder.ToTable("Candidate");
                builder.HasIndex(x => x.Email).IsUnique();
            });
            modelBuilder.Entity<Submission>(builder =>
            {
                builder.ToTable("Submission");
                builder.HasIndex(x => new { x.CandidateId, x.JobRequirementId }).IsUnique();
            });
        }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<JobRequirement> JobRequirement { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<SubmissionStatus> SubmissionStatuses { get; set; }
    }
}
