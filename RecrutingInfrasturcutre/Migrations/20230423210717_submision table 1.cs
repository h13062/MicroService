using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecrutingInfrastructure.Migrations
{
    public partial class submisiontable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: false),
                    EmailId = table.Column<string>(type: "varchar(150)", nullable: false),
                    ResumeURL = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobRequirement",
                columns: table => new
                {
                    JobRequirementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfPositions = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(512)", nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", nullable: false),
                    HiringManagerId = table.Column<int>(type: "int", nullable: false),
                    HiringManagerName = table.Column<string>(type: "varchar(512)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActivate = table.Column<bool>(type: "bit", nullable: false),
                    ClosedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedReason = table.Column<string>(type: "varchar(512)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobCategory = table.Column<string>(type: "varchar(512)", nullable: false),
                    EmployeeType = table.Column<string>(type: "varchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirement", x => x.JobRequirementId);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionStatuses",
                columns: table => new
                {
                    LookupCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionStatuses", x => x.LookupCode);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    SubmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRequirementId1 = table.Column<int>(type: "int", nullable: false),
                    CandidateIdId = table.Column<int>(type: "int", nullable: false),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RejectedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusLookupCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.SubmissionId);
                    table.ForeignKey(
                        name: "FK_Submissions_Candidate_CandidateIdId",
                        column: x => x.CandidateIdId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_JobRequirement_JobRequirementId1",
                        column: x => x.JobRequirementId1,
                        principalTable: "JobRequirement",
                        principalColumn: "JobRequirementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_SubmissionStatuses_StatusLookupCode",
                        column: x => x.StatusLookupCode,
                        principalTable: "SubmissionStatuses",
                        principalColumn: "LookupCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_CandidateIdId",
                table: "Submissions",
                column: "CandidateIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_JobRequirementId1",
                table: "Submissions",
                column: "JobRequirementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_StatusLookupCode",
                table: "Submissions",
                column: "StatusLookupCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "JobRequirement");

            migrationBuilder.DropTable(
                name: "SubmissionStatuses");
        }
    }
}
