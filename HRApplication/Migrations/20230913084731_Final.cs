using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApplication.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeAttendence_EmployeeAttendId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeAttendId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeAttendId",
                table: "Employee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeAttendId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeAttendId",
                table: "Employee",
                column: "EmployeeAttendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeAttendence_EmployeeAttendId",
                table: "Employee",
                column: "EmployeeAttendId",
                principalTable: "EmployeeAttendence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
