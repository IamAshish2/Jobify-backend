using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobify_Backend.Migrations
{
    /// <inheritdoc />
    public partial class isitfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Users_UserId",
                table: "JobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                table: "JobApplications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                columns: new[] { "JobId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Users_UserId",
                table: "JobApplications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Users_UserId",
                table: "JobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDate",
                table: "JobApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Users_UserId",
                table: "JobApplications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
