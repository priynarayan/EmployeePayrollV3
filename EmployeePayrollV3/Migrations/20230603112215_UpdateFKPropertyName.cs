using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePayrollV3.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFKPropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_JobClasses_JobClassId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "jobId",
                table: "Payrolls");

            migrationBuilder.RenameColumn(
                name: "JobClassId",
                table: "Payrolls",
                newName: "jobClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Payrolls_JobClassId",
                table: "Payrolls",
                newName: "IX_Payrolls_jobClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_JobClasses_jobClassId",
                table: "Payrolls",
                column: "jobClassId",
                principalTable: "JobClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_JobClasses_jobClassId",
                table: "Payrolls");

            migrationBuilder.RenameColumn(
                name: "jobClassId",
                table: "Payrolls",
                newName: "JobClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Payrolls_jobClassId",
                table: "Payrolls",
                newName: "IX_Payrolls_JobClassId");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Salaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "jobId",
                table: "Payrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
