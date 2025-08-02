using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_System.Migrations
{
    /// <inheritdoc />
    public partial class addingemp_projrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Project_Employee_EmployeeID",
                table: "Employee_Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Project_Projects_ProjectID",
                table: "Employee_Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Project",
                table: "Employee_Project");

            migrationBuilder.RenameTable(
                name: "Employee_Project",
                newName: "Employee_Projects");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Project_EmployeeID",
                table: "Employee_Projects",
                newName: "IX_Employee_Projects_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Projects",
                table: "Employee_Projects",
                columns: new[] { "ProjectID", "EmployeeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Projects_Employee_EmployeeID",
                table: "Employee_Projects",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Projects_Projects_ProjectID",
                table: "Employee_Projects",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Projects_Employee_EmployeeID",
                table: "Employee_Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Projects_Projects_ProjectID",
                table: "Employee_Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Projects",
                table: "Employee_Projects");

            migrationBuilder.RenameTable(
                name: "Employee_Projects",
                newName: "Employee_Project");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Projects_EmployeeID",
                table: "Employee_Project",
                newName: "IX_Employee_Project_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Project",
                table: "Employee_Project",
                columns: new[] { "ProjectID", "EmployeeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Project_Employee_EmployeeID",
                table: "Employee_Project",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Project_Projects_ProjectID",
                table: "Employee_Project",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
