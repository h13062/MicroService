using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewInfrastructure.Migrations
{
    public partial class fixforeignkeyissuesattempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_interviewTypes_InterviewTypeCode1",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewTypeCode1",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "InterviewTypeCode1",
                table: "Interview");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewTypeCode",
                table: "Interview",
                column: "InterviewTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_interviewTypes_InterviewTypeCode",
                table: "Interview",
                column: "InterviewTypeCode",
                principalTable: "interviewTypes",
                principalColumn: "InterviewTypeCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_interviewTypes_InterviewTypeCode",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewTypeCode",
                table: "Interview");

            migrationBuilder.AddColumn<int>(
                name: "InterviewTypeCode1",
                table: "Interview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewTypeCode1",
                table: "Interview",
                column: "InterviewTypeCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_interviewTypes_InterviewTypeCode1",
                table: "Interview",
                column: "InterviewTypeCode1",
                principalTable: "interviewTypes",
                principalColumn: "InterviewTypeCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
