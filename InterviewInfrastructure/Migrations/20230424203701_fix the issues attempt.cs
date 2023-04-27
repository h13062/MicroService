using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewInfrastructure.Migrations
{
    public partial class fixtheissuesattempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviewer_Interview_InterviewId",
                table: "Interviewer");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedBack_Interview_InterviewId",
                table: "InterviewFeedBack");

            migrationBuilder.DropForeignKey(
                name: "FK_interviewTypes_Interview_InterviewId",
                table: "interviewTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recruiter_Interview_InterviewId",
                table: "Recruiter");

            migrationBuilder.DropIndex(
                name: "IX_Recruiter_InterviewId",
                table: "Recruiter");

            migrationBuilder.DropIndex(
                name: "IX_interviewTypes_InterviewId",
                table: "interviewTypes");

            migrationBuilder.DropIndex(
                name: "IX_InterviewFeedBack_InterviewId",
                table: "InterviewFeedBack");

            migrationBuilder.DropIndex(
                name: "IX_Interviewer_InterviewId",
                table: "Interviewer");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "Recruiter");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "interviewTypes");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "InterviewFeedBack");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "Interviewer");

            migrationBuilder.AddColumn<int>(
                name: "InterviewFeedBackId",
                table: "Interview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewTypeCode",
                table: "Interview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewTypeCode1",
                table: "Interview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewerId",
                table: "Interview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecruiterID",
                table: "Interview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewerId",
                table: "Interview",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewFeedBackId",
                table: "Interview",
                column: "InterviewFeedBackId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewTypeCode1",
                table: "Interview",
                column: "InterviewTypeCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_RecruiterID",
                table: "Interview",
                column: "RecruiterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Interviewer_InterviewerId",
                table: "Interview",
                column: "InterviewerId",
                principalTable: "Interviewer",
                principalColumn: "InterviewerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_InterviewFeedBack_InterviewFeedBackId",
                table: "Interview",
                column: "InterviewFeedBackId",
                principalTable: "InterviewFeedBack",
                principalColumn: "InterviewFeedBackId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_interviewTypes_InterviewTypeCode1",
                table: "Interview",
                column: "InterviewTypeCode1",
                principalTable: "interviewTypes",
                principalColumn: "InterviewTypeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Recruiter_RecruiterID",
                table: "Interview",
                column: "RecruiterID",
                principalTable: "Recruiter",
                principalColumn: "RecruiterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Interviewer_InterviewerId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_InterviewFeedBack_InterviewFeedBackId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_interviewTypes_InterviewTypeCode1",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Recruiter_RecruiterID",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewerId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewFeedBackId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewTypeCode1",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_RecruiterID",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "InterviewFeedBackId",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "InterviewTypeCode",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "InterviewTypeCode1",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "InterviewerId",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "RecruiterID",
                table: "Interview");

            migrationBuilder.AddColumn<int>(
                name: "InterviewId",
                table: "Recruiter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewId",
                table: "interviewTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewId",
                table: "InterviewFeedBack",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewId",
                table: "Interviewer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recruiter_InterviewId",
                table: "Recruiter",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_interviewTypes_InterviewId",
                table: "interviewTypes",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewFeedBack_InterviewId",
                table: "InterviewFeedBack",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviewer_InterviewId",
                table: "Interviewer",
                column: "InterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviewer_Interview_InterviewId",
                table: "Interviewer",
                column: "InterviewId",
                principalTable: "Interview",
                principalColumn: "InterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedBack_Interview_InterviewId",
                table: "InterviewFeedBack",
                column: "InterviewId",
                principalTable: "Interview",
                principalColumn: "InterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_interviewTypes_Interview_InterviewId",
                table: "interviewTypes",
                column: "InterviewId",
                principalTable: "Interview",
                principalColumn: "InterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiter_Interview_InterviewId",
                table: "Recruiter",
                column: "InterviewId",
                principalTable: "Interview",
                principalColumn: "InterviewId");
        }
    }
}
