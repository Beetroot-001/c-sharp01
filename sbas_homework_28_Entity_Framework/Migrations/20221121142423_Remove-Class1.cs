using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sbashomework28EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemoveClass1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable
                (
                name:"Class1",
                newName:"NewNable"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
