using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewInfrastructure.Migrations
{
    public partial class firstattempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    InterviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewRound = table.Column<int>(type: "int", nullable: false),
                    ScheduleOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.InterviewId);
                });

            migrationBuilder.CreateTable(
                name: "Interviewer",
                columns: table => new
                {
                    InterviewerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FistName = table.Column<string>(type: "varchar(512)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(512)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    InterviewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewer", x => x.InterviewerID);
                    table.ForeignKey(
                        name: "FK_Interviewer_Interview_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interview",
                        principalColumn: "InterviewId");
                });

            migrationBuilder.CreateTable(
                name: "InterviewFeedBack",
                columns: table => new
                {
                    InterviewFeedBackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(max)", nullable: false),
                    InterviewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewFeedBack", x => x.InterviewFeedBackId);
                    table.ForeignKey(
                        name: "FK_InterviewFeedBack_Interview_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interview",
                        principalColumn: "InterviewId");
                });

            migrationBuilder.CreateTable(
                name: "interviewTypes",
                columns: table => new
                {
                    InterviewTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(512)", nullable: false),
                    InterviewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interviewTypes", x => x.InterviewTypeCode);
                    table.ForeignKey(
                        name: "FK_interviewTypes_Interview_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interview",
                        principalColumn: "InterviewId");
                });

            migrationBuilder.CreateTable(
                name: "Recruiter",
                columns: table => new
                {
                    RecruiterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FistName = table.Column<string>(type: "varchar(512)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(512)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    InterviewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiter", x => x.RecruiterId);
                    table.ForeignKey(
                        name: "FK_Recruiter_Interview_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interview",
                        principalColumn: "InterviewId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviewer_InterviewId",
                table: "Interviewer",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewFeedBack_InterviewId",
                table: "InterviewFeedBack",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_interviewTypes_InterviewId",
                table: "interviewTypes",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruiter_InterviewId",
                table: "Recruiter",
                column: "InterviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interviewer");

            migrationBuilder.DropTable(
                name: "InterviewFeedBack");

            migrationBuilder.DropTable(
                name: "interviewTypes");

            migrationBuilder.DropTable(
                name: "Recruiter");

            migrationBuilder.DropTable(
                name: "Interview");
        }
    }
}
