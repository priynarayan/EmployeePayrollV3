using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePayrollV3.Migrations
{
    /// <inheritdoc />
    public partial class removedJobsFKFromPayroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_JobClasses_JobClassId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_JobClassId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "JobClassId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "jobId",
                table: "Payrolls");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobClassId",
                table: "Payrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "jobId",
                table: "Payrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_JobClassId",
                table: "Payrolls",
                column: "JobClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_JobClasses_JobClassId",
                table: "Payrolls",
                column: "JobClassId",
                principalTable: "JobClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
