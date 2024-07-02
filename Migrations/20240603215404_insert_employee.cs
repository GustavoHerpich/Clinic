using Clinic.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class insert_employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //string[] columns = { nameof(Employee.Id), nameof(Employee.UserName), nameof(Employee.Password), nameof(Employee.Role) };
            //object[,] values = new object[,]
            //{
            //    { 1 , "dhiu", "senha" , 0}
            //};

            //migrationBuilder.InsertData("Employees", columns, values);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
